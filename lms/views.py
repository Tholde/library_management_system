import os.path
from datetime import datetime

from django.contrib.staticfiles import finders
from django.utils import timezone as tz
import random
from io import BytesIO
from barcode import EAN13
from barcode.writer import ImageWriter
from django.core.files import File
from django.core.paginator import Paginator
from django.contrib.auth.hashers import make_password, check_password
from django.shortcuts import redirect, render
from django.views.generic import View

from farany import settings
from django.core.mail import send_mail
from django.http import HttpResponse, JsonResponse
from xhtml2pdf import pisa
from django.template.loader import get_template, render_to_string

from farany.settings import BASE_DIR
from lms.models import Book, Librarian, Member, Admin, Borrow
from lms.utils import render_to_pdf


# page urls
def index(request):
    if request.session.get('user_id'):
        return redirect('dash_user')
    elif request.session.get('lbr_id'):
        return redirect('dash')
    elif request.session.get('admin_id'):
        return redirect('dash_admin')
    else:
        return render(request, 'login.html')


def register(request):
    return render(request, 'register.html')


def forget_pass(request):
    return render(request, 'forgot-password.html')


def dashboard(request):
    if not request.session.get('lbr_id'):
        return render(request, 'login.html')
    else:
        mbr = Member.objects.all()  # SELECT * FROM lms_member
        lbr = Librarian.objects.all()  # SELECT * FROM lms_librarian
        bk = Book.objects.all()  # SELECT * FROM lms_member
        recent_user_entries = Member.objects.order_by('-created_date')[
                              :3]  # SELECT * FROM lms_member ORDER BY created_date DESC LIMIT 3;
        recent_book_entries = Book.objects.order_by('-created_date')[
                              :3]  # SELECT * FROM lms_book ORDER BY created_date DESC LIMIT 3;
        br = Borrow.objects.all()
        context = {'member': mbr, 'lbr': lbr, 'bk': bk, 'recent_user': recent_user_entries,
                   'recent_book': recent_book_entries, 'br': br}
        return render(request, 'librarian/dashboard.html', context)


def user_dashboard(request):
    if not request.session.get('user_id'):
        return render(request, 'login.html')
    else:
        lbr = Librarian.objects.all()  # SELECT * FROM lms_librarian
        bk = Book.objects.all()  # SELECT * FROM lms_member
        recent_book_entries = Book.objects.order_by('-created_date')[
                              :3]  # SELECT * FROM lms_book ORDER BY created_date DESC LIMIT 3;
        pk = request.session.get('user_id')
        br = Borrow.objects.filter(id_user=pk)
        context = {'bk': bk, 'recent_book': recent_book_entries, 'br': br}
        return render(request, 'user/dashboard.html', context)


def admin_dashboard(request):
    if not request.session.get('admin_id'):
        return render(request, 'login.html')
    else:
        mbr = Member.objects.all()  # SELECT * FROM lms_member
        lbr = Librarian.objects.all()  # SELECT * FROM lms_librarian
        bk = Book.objects.all()  # SELECT * FROM lms_member
        recent_user_entries = Member.objects.order_by('-created_date')[
                              :3]  # SELECT * FROM lms_member ORDER BY created_date DESC LIMIT 3;
        recent_book_entries = Book.objects.order_by('-created_date')[
                              :3]  # SELECT * FROM lms_book ORDER BY created_date DESC LIMIT 3;
        br = Borrow.objects.all()
        context = {'member': mbr, 'lbr': lbr, 'bk': bk, 'recent_user': recent_user_entries,
                   'recent_book': recent_book_entries, 'br': br}
        return render(request, 'admin/dashboard.html', context)


def librarian_manage(request):
    if not request.session.get('admin_id'):
        return render(request, 'login.html')
    else:
        lbr = Librarian.objects.all()
        return render(request, 'admin/manage_librarian.html', {'librarian': lbr})


def book_manage(request):
    if not request.session.get('lbr_id') and not request.session.get('admin_id'):
        return render(request, 'login.html')
    else:
        if request.session.get('admin_id'):
            # book = Book.objects.all().order_by('-created_date')
            book = Book.objects.filter(is_borrowed=False).order_by('-created_date')
            selected_category = request.GET.get('category', 'All')
            if selected_category != 'All':
                book = book.filter(category=selected_category)
            search_query = request.GET.get('search', '')
            if search_query:
                book = book.filter(title=search_query) | book.filter(
                    author=search_query)
            current_page = request.GET.get('page', 1)
            items_per_page = 10
            paginator = Paginator(book, items_per_page)
            page_data = paginator.get_page(current_page)
            total_pages = paginator.num_pages
            has_prev = page_data.has_previous()
            has_next = page_data.has_next()
            categories = Book.objects.values_list('category', flat=True).distinct()

            context = {
                'books': page_data,  # Pass the current page data (list of books)
                'categories': categories,  # Optional: List of all categories (for dropdown)
                'selected_category': selected_category,  # Optional: Currently selected category
                'search_query': search_query,  # Optional: Current search query
                'total_pages': total_pages,  # Optional: total number of pages
                'has_prev': has_prev,  # Optional: flag for previous page existence
                'has_next': has_next,  # Optional: flag for next page existence
            }
            return render(request, 'admin/manage_book.html', context)
        else:
            # book = Book.objects.all().order_by('-created_date')
            book = Book.objects.filter(is_borrowed=False).order_by('-created_date')
            selected_category = request.GET.get('category', 'All')
            if selected_category != 'All':
                book = book.filter(category=selected_category)
            search_query = request.GET.get('search', '')
            if search_query:
                book = book.filter(title=search_query) | book.filter(
                    author=search_query)
            current_page = request.GET.get('page', 1)
            items_per_page = 10
            paginator = Paginator(book, items_per_page)
            page_data = paginator.get_page(current_page)
            total_pages = paginator.num_pages
            has_prev = page_data.has_previous()
            has_next = page_data.has_next()
            categories = Book.objects.values_list('category', flat=True).distinct()

            context = {
                'books': page_data,  # Pass the current page data (list of books)
                'categories': categories,  # Optional: List of all categories (for dropdown)
                'selected_category': selected_category,  # Optional: Currently selected category
                'search_query': search_query,  # Optional: Current search query
                'total_pages': total_pages,  # Optional: total number of pages
                'has_prev': has_prev,  # Optional: flag for previous page existence
                'has_next': has_next,  # Optional: flag for next page existence
            }
            return render(request, 'librarian/manage_book.html', context)


def librarian_profile(request):
    if not request.session.get('lbr_id'):
        return render(request, 'login.html')
    else:
        pk = request.session.get('lbr_id')
        lbr = Librarian.objects.get(id=pk)
        return render(request, 'librarian/librarian_profile.html', {'lbr': lbr})


def admin_profile(request):
    if not request.session.get('admin_id'):
        return render(request, 'login.html')
    else:
        pk = request.session.get('admin_id')
        adm = Admin.objects.get(id=pk)
        return render(request, 'admin/admin_profile.html', {'adm': adm})


def add_librarian(request):
    if not request.session.get('admin_id'):
        return render(request, 'login.html')
    else:
        return render(request, 'admin/add_librarian.html')


def add_book(request):
    if not request.session.get('lbr_id') and not request.session.get('admin_id'):
        return render(request, 'login.html')
    else:
        if request.session.get('admin_id'):
            return render(request, 'admin/add_book.html')
        else:
            return render(request, 'librarian/add_book.html')


def edit_book(request, pk):
    if not request.session.get('lbr_id') and not request.session.get('admin_id'):
        return render(request, 'login.html')
    else:
        if request.session.get('admin_id'):
            book = Book.objects.get(id=pk)
            return render(request, 'admin/edit_book.html', {'book': book})
        else:
            book = Book.objects.get(id=pk)
            return render(request, 'librarian/edit_book.html', {'book': book})


def edit_librarian(request, pk):
    if not request.session.get('admin_id'):
        return render(request, 'login.html')
    else:
        lbr = Librarian.objects.get(id=pk)
        return render(request, 'admin/edit_librarian.html', {'lbr': lbr})


def admin_manage(request):
    if not request.session.get('admin_id'):
        return render(request, 'login.html')
    else:
        admin = Admin.objects.all().order_by('-id')
        return render(request, 'admin/manage_admin.html', {'admin': admin})


def user_profile(request):
    if not request.session.get('user_id'):
        return render(request, 'login.html')
    else:
        pk = request.session.get('user_id')
        user = Member.objects.get(id=pk)
        return render(request, 'user/user_profile.html', {'user': user})


def add_admin(request):
    if not request.session.get('admin_id'):
        return render(request, 'login.html')
    else:
        return render(request, 'admin/add_admin.html')


def edit_admin(request, pk):
    if not request.session.get('admin_id'):
        return render(request, 'login.html')
    else:
        admin = Admin.objects.get(id=pk)
        return render(request, 'admin/edit_admin.html', {'admin': admin})


def borrow_manage(request):
    if not request.session.get('lbr_id') and not request.session.get('admin_id'):
        return render(request, 'login.html')
    else:
        if request.session.get('admin_id'):
            try:
                borrow = Borrow.objects.all().order_by('-id')
                id_books = []
                id_users = []
                for i in borrow:
                    id_books.append(i.id_book)
                    id_users.append(i.id_user)
                title_list = []
                user_list = []
                book = Book.objects.all()
                user = Member.objects.all()
                for id_book in id_books:
                    for bk in book.filter(id=id_book):
                        title_list.append(bk.title)
                for id_user in id_users:
                    for usr in user.filter(id=id_user):
                        user_list.append(usr.firstname)
                borrow_date = []
                status_list = []
                normal_return_list = []
                for brw in borrow:
                    borrow_date.append(brw.borrow_date)
                    status_list.append(brw.note)
                    normal_return_list.append(brw.return_date)
                result_list = []
                for i in range(len(title_list)):
                    result_list.append(
                        (title_list[i], user_list[i], borrow_date[i], normal_return_list[i], status_list[i]))
                context = {'result_list': result_list}
                print(result_list)
                return render(request, 'admin/manage_borrow.html', context)
            except Exception as e:
                return render(request, 'admin/manage_borrow.html')
        else:
            try:
                borrow = Borrow.objects.all().order_by('-id')
                id_books = []
                id_users = []
                for i in borrow:
                    id_books.append(i.id_book)
                    id_users.append(i.id_user)
                title_list = []
                user_list = []
                book = Book.objects.all()
                user = Member.objects.all()
                for id_book in id_books:
                    for bk in book.filter(id=id_book):
                        title_list.append(bk.title)
                for id_user in id_users:
                    for usr in user.filter(id=id_user):
                        user_list.append(usr.firstname)
                borrow_date = []
                status_list = []
                normal_return_list = []
                for brw in borrow:
                    borrow_date.append(brw.borrow_date)
                    status_list.append(brw.note)
                    normal_return_list.append(brw.return_date)
                result_list = []
                for i in range(len(title_list)):
                    result_list.append(
                        (title_list[i], user_list[i], borrow_date[i], normal_return_list[i], status_list[i]))
                context = {'result_list': result_list}
                print(result_list)
                return render(request, 'librarian/manage_borrow.html', context)
            except Exception as e:
                return render(request, 'librarian/manage_borrow.html')


def borrow_list_id(request):
    if not request.session.get('lbr_id') and not request.session.get('admin_id'):
        return render(request, 'login.html')
    else:
        if request.session.get('admin_id'):
            br = Borrow.objects.all().order_by('-id')
            context = {'borrow': br}
            return render(request, 'admin/borrow_list.html', context)
        else:
            br = Borrow.objects.all().order_by('-id')
            context = {'borrow': br}
            return render(request, 'librarian/borrow_list.html', context)


def edit_borrow(request, pk):
    if not request.session.get('lbr_id') and not request.session.get('admin_id'):
        return render(request, 'login.html')
    else:
        if request.session.get('admin_id'):
            br = Borrow.objects.get(id=pk)
            user = Member.objects.get(id=br.id_user)
            book = Book.objects.get(id=br.id_book)
            context = {'borrow': br, 'member': user, 'book': book}
            return render(request, 'admin/edit_borrow.html', context)
        else:
            br = Borrow.objects.get(id=pk)
            user = Member.objects.get(id=br.id_user)
            book = Book.objects.get(id=br.id_book)
            context = {'borrow': br, 'member': user, 'book': book}
            return render(request, 'librarian/edit_borrow.html', context)


def borrow_book(request):
    if not request.session.get('user_id'):
        return render(request, 'login.html')
    else:
        try:
            pk = request.session.get('user_id')
            borrowed = Borrow.objects.filter(id_user=pk, is_return=False)
            # lid = borrowed[0].id_book
            # book = Book.objects.filter(id=lid)
            if len(borrowed) != 0:
                id_books = [item.id_book for item in borrowed]
                bok = Book.objects.all()
                book = bok.filter(id=id_books[0])
                return render(request, 'user/borrow_book.html', {'books': book})
        except Exception as e:
            return render(request, 'user/borrow_book.html')
        return render(request, 'user/borrow_book.html')


def book_list(request):
    if not request.session.get('user_id'):
        return render(request, 'login.html')
    else:
        try:
            book = Book.objects.filter(is_borrowed=False).order_by('-created_date')
            selected_category = request.GET.get('category', 'All')
            if selected_category != 'All':
                book = book.filter(category=selected_category)
            search_query = request.GET.get('search', '')
            if search_query:
                book = book.filter(title=search_query) | book.filter(author=search_query) | book.filter(
                    isbn=search_query) | book.filter(pub_date=search_query)
            current_page = request.GET.get('page', 1)
            items_per_page = 10
            paginator = Paginator(book, items_per_page)
            page_data = paginator.get_page(current_page)
            total_pages = paginator.num_pages
            has_prev = page_data.has_previous()
            has_next = page_data.has_next()
            categories = Book.objects.values_list('category', flat=True).distinct()
            context = {
                'books': page_data,  # Pass the current page data (list of books)
                'categories': categories,  # Optional: List of all categories (for dropdown)
                'selected_category': selected_category,  # Optional: Currently selected category
                'search_query': search_query,  # Optional: Current search query
                'total_pages': total_pages,  # Optional: total number of pages
                'has_prev': has_prev,  # Optional: flag for previous page existence
                'has_next': has_next,  # Optional: flag for next page existence
            }
            return render(request, 'user/list_book.html', context)
        except Book.DoesNotExist:
            return render(request, 'user/list_book.html')


# action url
# Book
def save_user(request):
    if request.method == 'POST':
        fname = request.POST.get('first_name')
        lname = request.POST.get('last_name')
        mail = request.POST.get('email')
        pwd = request.POST.get('password')
        cofpwd = request.POST.get('password_repeat')
        create = datetime.now()
        update = datetime.now()
        if pwd == cofpwd:
            password = make_password(pwd)
            mbr = Member(firstname=fname, lastname=lname, mail=mail, password=password, created_date=create,
                         updated_date=update)
            mbr.save()
            return redirect('index')
        else:
            return render(request, 'register.html')
    return render(request, 'register.html')


def update_book(request, pk):
    if request.method == 'POST':
        title = request.POST.get('title')
        author = request.POST.get('author')
        pub_date = request.POST.get('pub_date')
        category = request.POST.get('category')
        update = datetime.now()
        bk = Book.objects.get(id=pk)
        bk.title = title
        bk.author = author
        bk.pub_date = pub_date
        bk.category = category
        bk.updated_date = update
        bk.save()
    return redirect('book')


def save_book(request):
    if request.method == 'POST':
        title = request.POST.get('title')
        author = request.POST.get('author')
        pub_date = request.POST.get('pub_date')
        category = request.POST.get('category')
        create = datetime.now()
        update = datetime.now()
        isbn = "100" + ''.join(random.choices('0123456789', k=10))  # ny number telo voalohany tsy miova
        bk = Book(isbn=isbn, title=title, author=author, pub_date=pub_date, category=category, created_date=create,
                  updated_date=update)
        ean = EAN13(isbn, writer=ImageWriter())
        buffer = BytesIO()
        ean.write(buffer)
        buffer.seek(0)
        bk.barcode.save(f'{bk.isbn}.png', File(buffer), save=False)
        bk.save()
    return redirect('book')


def delete_book(request, pk):
    if not request.session.get('lbr_id') and not request.session.get('admin_id'):
        return render(request, 'login.html')
    else:
        bk = Book.objects.get(id=pk)
        bk.delete()
        return redirect('book')


# Librarian
def save_librarian(request):
    if request.method == 'POST':
        address = request.POST.get('local_address')
        email = request.POST.get('mail')
        fname = request.POST.get('firstname')
        lname = request.POST.get('lastname')
        password = request.POST.get('password')
        create = datetime.now()
        update = datetime.now()
        cofpassword = request.POST.get('confirm_password')
        if password == cofpassword:
            lbr = Librarian(firstname=fname, lastname=lname, address=address, mail=email, password=password,
                            created_date=create, updated_date=update)
            lbr.save()
            return redirect('librarian')
        else:
            return render(request, 'admin/add_librarian.html')
    return render(request, 'admin/add_librarian.html')


def update_librarian(request, pk):
    if request.method == 'POST':
        address = request.POST.get('local_address')
        email = request.POST.get('mail')
        fname = request.POST.get('firstname')
        lname = request.POST.get('lastname')
        password = request.POST.get('password')
        update = datetime.now()
        cofpassword = request.POST.get('confirm_password')
        if password == cofpassword:
            lbr = Librarian.objects.get(id=pk)
            lbr.firstname = fname
            lbr.lastname = lname
            lbr.address = address
            lbr.mail = email
            lbr.password = password
            lbr.updated_date = update
            lbr.save()
            return redirect('librarian')


def delete_librarian(request, pk):
    if not request.session.get('admin_id'):
        return render(request, 'login.html')
    else:
        lbr = Librarian.objects.get(id=pk)
        lbr.delete()
        return redirect('librarian')


def update_librarian_profile(request):
    if request.method == 'POST':
        address = request.POST.get('address')
        email = request.POST.get('email')
        fname = request.POST.get('first_name')
        lname = request.POST.get('last_name')
        password = request.POST.get('password')
        update = datetime.now()
        cofpassword = request.POST.get('confirm_password')
        if password == cofpassword:
            pk = request.session.get('lbr_id')
            lbr = Librarian.objects.get(id=pk)
            lbr.firstname = fname
            lbr.lastname = lname
            lbr.address = address
            lbr.mail = email
            lbr.password = password
            lbr.updated_date = update
            lbr.save()
            return redirect('profile')
        else:
            return redirect('profile')
    return redirect('profile')


def save_admin(request):
    if request.method == 'POST':
        username = request.POST.get('username')
        mail = request.POST.get('mail')
        pwd = request.POST.get('password')
        cofpwd = request.POST.get('confirm_password')
        if pwd == cofpwd:
            admin = Admin(username=username, email=mail, password=pwd)
            admin.save()
            return redirect('admin_manage')
        else:
            return redirect('add_admin')
    return redirect('add_admin')


def update_admin(request, pk):
    if request.method == 'POST':
        username = request.POST.get('username')
        mail = request.POST.get('mail')
        pwd = request.POST.get('password')
        cofpwd = request.POST.get('confirm_password')
        if pwd == cofpwd:
            admin = Admin.objects.get(id=pk)
            admin.username = username
            admin.email = mail
            admin.password = pwd
            admin.save()
            return redirect('admin_manage')


def delete_admin(request, pk):
    if not request.session.get('admin_id'):
        return render(request, 'login.html')
    else:
        admin = Admin.objects.get(id=pk)
        admin.delete()
        return redirect('admin_manage')


def update_admin_profile(request):
    if request.method == 'POST':
        username = request.POST.get('username')
        mail = request.POST.get('email')
        pwd = request.POST.get('password')
        cofpwd = request.POST.get('confirm_password')
        if not request.session.get('admin_id'):
            return render(request, 'login.html')
        else:
            if pwd == cofpwd:
                pk = request.session.get('admin_id')
                admin = Admin.objects.get(id=pk)
                admin.username = username
                admin.email = mail
                admin.password = pwd
                admin.save()
                return redirect('dash_admin')


def update_user_profile(request):
    if request.method == 'POST':
        address = request.POST.get('addres')
        fname = request.POST.get('first_name')
        lname = request.POST.get('last_name')
        mail = request.POST.get('mail')
        pwd = request.POST.get('password')
        cofpwd = request.POST.get('confirm_password')
        update = datetime.now()
        if pwd == cofpwd:
            password = make_password(pwd)
            pk = request.session.get('user_id')
            mbr = Member.objects.get(id=pk)
            mbr.firstname = fname
            mbr.lastname = lname
            mbr.mail = mail
            mbr.address = address
            mbr.password = password
            mbr.updated_date = update
            mbr.save()
            return redirect('dash_user')
    return redirect('user_profile')


def borrow_bk(request, pk):
    if not request.session.get('user_id'):
        return render(request, 'login.html')
    else:
        book = Book.objects.get(id=pk)
        id_user = request.session.get('user_id')
        id_book = book.id
        borrow_date = tz.now()
        return_date = borrow_date + tz.timedelta(days=3)
        note = "in regression"
        br = Borrow(id_user=id_user, id_book=id_book, borrow_date=borrow_date, return_date=return_date, note=note)
        br.save()
        book.is_borrowed = True
        book.save()
        return redirect('book_list')


def return_borrow(request, pk):
    if not request.session.get('user_id'):
        return render(request, 'login.html')
    else:
        try:
            book = Book.objects.get(id=pk)
            br = Borrow.objects.get(id_book=book.id, is_return=False)
            after = tz.now()
            days_number = after - br.return_date  # calcul number of borrow days
            days = days_number.days
            if int(days) > 0:
                br.note = f"late {days} days"
                br.is_return = True
                br.save()
                book.is_borrowed = False
                book.save()
                id_user = request.session.get('user_id')
                user = Member.objects.get(id=id_user)
                to_mail = "tholde.pathfinder@gmail.com"  # e-mail admin receiver
                send_mail(
                    subject="Latest book",
                    message=f"There is new late borrow, please try to see it. There name is {user.firstname}.\n"
                            f"Late Number Days: {days} days",
                    from_email=settings.EMAIL_HOST_USER,
                    recipient_list=[to_mail],
                    fail_silently=True,

                )
                return redirect('book_list')
            else:
                br.note = f"normal"
                br.is_return = True
                br.save()
                book.is_borrowed = False
                book.save()
                return redirect('book_list')
        except Borrow.DoesNotExist:
            return redirect('borrow_book')


def delete_borrow(request, pk):
    if not request.session.get('lbr_id') and not request.session.get('admin_id'):
        return render(request, 'login.html')
    else:
        br = Borrow.objects.get(id=pk)
        br.delete()
        return redirect('borrow')


def update_borrow(request, pk):
    if request.method == 'POST':
        borrow_date = request.POST.get('borrow_date')
        return_date = request.POST.get('return_date')
        br = Borrow.objects.get(id=pk)
        br.borrow_date = borrow_date
        br.return_date = return_date
        br.save()
        return redirect('borrow')


# login url
def connection(request):
    if request.method == 'POST':
        selected_option = request.POST.get('selected_position')
        email = request.POST.get('email')
        passwrd = request.POST.get('password')
        if selected_option == "user":
            mbr = Member.objects.filter(mail=email).first()
            if mbr:
                pwd = check_password(passwrd, mbr.password)
                if pwd:
                    request.session['user_id'] = mbr.id
                    return redirect('dash_user')
                else:
                    return redirect('index')
            else:
                return redirect('index')
        elif selected_option == "librarian":
            lbr = Librarian.objects.filter(mail=email).first()
            if lbr:
                if lbr.password == passwrd:
                    request.session['lbr_id'] = lbr.id
                    return redirect('dash')
                else:
                    return redirect('index')
            else:
                return redirect('index')
        elif selected_option == "admin":
            adm = Admin.objects.filter(email=email).first()
            if adm:
                # pwd = check_password(passwrd, adm.password)
                if adm.password == passwrd:
                    request.session['admin_id'] = adm.id
                    return redirect('dash_admin')
                else:
                    return redirect('index')
            else:
                return redirect('index')
    return redirect('index')


def logout_user(request):
    request.session.pop('user_id', None)
    request.session.modified = True
    return redirect('index')


def logout_librarian(request):
    request.session.pop('lbr_id', None)
    request.session.modified = True
    return redirect('index')


def logout_admin(request):
    request.session.pop('admin_id', None)
    request.session.modified = True
    return redirect('index')


    # generate pdf
    # def render_pdf_view(request):
    #     # html = render_to_string('librarian/manage_borrow.html', {'borrow_list': })
    #     template_path = 'librarian/manage_borrow.html'
    #     context = {'var': 'this is your template context'}
    #     response = HttpResponse(content_type='application/pdf')
    #     response['Content-Disposition'] = 'attachment; filename= "borrow_list.pdf"'
    #     template = get_template(template_path)
    #     html = template.render(context)
    #     pisa_status = pisa.CreatePDF(
    #         html, dest=response
    #     )
    #     if pisa_status.err:
    #         return HttpResponse('We had some errors <pre>' + html + '</pre>')
    #     return response

    # class GeneratePdf(APIView):
    #     def get(self, request):
    #        pdf = render_to_pdf('librarian/manage_book.html')
    #        return HttpResponse(pdf, content_type='application/pdf')

    # class GeneratePdf(View):
    #     def get(self, request, *args, **kwargs):
    #        pdf = render_to_pdf('librarian/manage_book.html')
    #        return HttpResponse(pdf, content_type='application/pdf')
    #
    # class GeneratePdf(View):
    #     def get(self, request, *args, **kwargs):
    #         book = Book.objects.all().order_by('-id')
    #         data = {
    #             'title': book[0].title,
    #             'author': book[0].author,
    #             'isbn': book[0].isbn,
    #             'pub_date': book[0].pub_date,
    #             'category': book[0].category,
    #             'barcode': book[0].barcode.url,
    #             'created_date': book[0].created_date,
    #             'updated_date': book[0].updated_date
    #         }
    #         print(data)
    #         pdf = render_to_pdf('librarian/manage_book.html', data)
    #         if pdf:
    #             response = HttpResponse(pdf, content_type='application/pdf')
    #             filename = 'manage_book.pdf'
    #             content = "inline; filename= %s" % filename
    #             response['Content-Disposition'] = content
    #             return response
    #         return HttpResponse("Page not found")
    # def generate_pdf(request):
    #     book = Book.objects.all().order_by('-id')
    #     template_path = os.path.join(BASE_DIR, 'templates', 'librarian/manage_book.html')
    #     rendered_html = render_to_string(template_path, {'books': book})
    #
    #     response = HttpResponse(content_type='application/pdf')
    #     response['Content-Disposition'] = 'attachment; filename=book.pdf'
    #
    #     # pisa configuration (optional)
    #     pisa.CreatePDF(rendered_html, response, link_callback=lambda url, rel: None)
    #
    #     return response


# def link_callback(uri, rel):
#     """
#     Convert HTML URIs to absolute system paths so xhtml2pdf can access those
#     resources
#     """
#     result = finders.find(uri)
#     if result:
#         if not isinstance(result, (list, tuple)):
#             result = [result]
#         result = list(os.path.realpath(path) for path in result)
#         path = result[0]
#     else:
#         sUrl = settings.STATIC_URL  # Typically /static/
#         sRoot = settings.STATIC_ROOT  # Typically /home/userX/project_static/
#         mUrl = settings.MEDIA_URL  # Typically /media/
#         mRoot = settings.MEDIA_ROOT  # Typically /home/userX/project_static/media/
#
#         if uri.startswith(mUrl):
#             path = os.path.join(mRoot, uri.replace(mUrl, ""))
#         elif uri.startswith(sUrl):
#             path = os.path.join(sRoot, uri.replace(sUrl, ""))
#         else:
#             return uri
#
#         # make sure that file exists
#         if not os.path.isfile(path):
#             raise RuntimeError(
#                 f'media URI must start with {sUrl} or {mUrl}'
#             )
#     return path
#
#
# def render_pdf_view(request):
#     template_path = 'librarian/manage_book.html'
#     context = {'myvar': 'this is your template context'}
#     # Create a Django response object, and specify content_type as pdf
#     response = HttpResponse(content_type='application/pdf')
#     response['Content-Disposition'] = 'attachment; filename="report.pdf"'
#     # find the template and render it.
#     template = get_template(template_path)
#     html = template.render(context)
#
#     # create a pdf
#     pisa_status = pisa.CreatePDF(
#         html, dest=response, link_callback=link_callback)
#     # if error then show some funny view
#     if pisa_status.err:
#         return HttpResponse('We had some errors <pre>' + html + '</pre>')
#     return response
