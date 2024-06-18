from django.contrib import admin

from lms.models import Admin, Member, Librarian, Book, Borrow


class AdminAdmin(admin.ModelAdmin):
    list_display = "username", "email", "password"


class MemberAdmin(admin.ModelAdmin):
    list_display = "firstname", "lastname", "address", "mail", "password", "created_date", "updated_date"


class LibrarianAdmin(admin.ModelAdmin):
    list_display = "firstname", "lastname", "address", "mail", "password", "created_date", "updated_date"


class BookAdmin(admin.ModelAdmin):
    list_display = "isbn", "title", "author", "pub_date", "category", "barcode", "created_date", "updated_date"


class BorrowAdmin(admin.ModelAdmin):
    list_display = "id_book", "id_user","is_return", "borrow_date", "return_date", "updated_date", "note"


# Register your models here.
admin.site.register(Admin, AdminAdmin)
admin.site.register(Member, MemberAdmin)
admin.site.register(Librarian, LibrarianAdmin)
admin.site.register(Book, BookAdmin)
admin.site.register(Borrow, BorrowAdmin)
