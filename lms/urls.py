from django.urls import path
from . import views

urlpatterns = [
    path('', views.index, name="index"),
    path('registration/', views.register, name="register"),
    path('forgot-password/', views.forget_pass, name="forgot_password"),
    path('regUser/', views.save_user, name="registration"),
    path('logUser/', views.connection, name="login"),
    path('dashboard/', views.dashboard, name="dash"),
    path('user-dashboard/', views.user_dashboard, name="dash_user"),
    path('admin-dashboard/', views.admin_dashboard, name="dash_admin"),
    path('logoutUser/', views.logout_user, name="logout_user"),
    path('logoutLibrarian/', views.logout_librarian, name="logout_librarian"),
    path('logoutAdmin/', views.logout_admin, name="logout_admin"),
    path('librarian-Manage/', views.librarian_manage, name="librarian"),
    path('book-Manage/', views.book_manage, name="book"),
    path('librarian-profile/', views.librarian_profile, name="profile"),
    path('add-lib/', views.add_librarian, name="add_librarian"),
    path('save-librarian/', views.save_librarian, name="insert_lib"),
    path('add-bk/', views.add_book, name="add_book"),
    path('save-book/', views.save_book, name="insert_book"),
    path('edit_book/<int:pk>/', views.edit_book, name="edit_book"),
    path('update_book/<int:pk>/', views.update_book, name="update_book"),
    path('delete_book/<int:pk>/', views.delete_book, name="delete_book"),
    path('edit_librarian/<int:pk>/', views.edit_librarian, name="edit_librarian"),
    path('update_librarian/<int:pk>/', views.update_librarian, name="update_librarian"),
    path('delete_librarian/<int:pk>/', views.delete_librarian, name="delete_librarian"),
    path('update_librarian_profile', views.update_librarian_profile, name="update_librarian_profile"),
    path('admin-manage/', views.admin_manage, name="admin_manage"),
    path('add-admin/', views.add_admin, name="add_admin"),
    path('save-admin/', views.save_admin, name="insert_admin"),
    path('edit_admin/<int:pk>/', views.edit_admin, name="edit_admin"),
    path('update_admin/<int:pk>/', views.update_admin, name="update_admin"),
    path('delete_admin/<int:pk>/', views.delete_admin, name="delete_admin"),
    path('admin_profile', views.admin_profile, name="admin_profile"),
    path('update_admin_profile', views.update_admin_profile, name="update_admin_profile"),
    path('user_profile', views.user_profile, name="user_profile"),
    path('update_user_profile', views.update_user_profile, name="update_user_profile"),
    path('borrow-Manage/', views.borrow_manage, name="borrow"),
    path('borrow-book/', views.borrow_book, name="borrow_book"),
    path('borrowed-book/<int:pk>', views.borrow_bk, name="borrow_bk"),
    path('return-borrow/<int:pk>', views.return_borrow, name="return_borrow"),
    path('book-list/', views.book_list, name="book_list"),
    path('borrow-list/', views.borrow_list_id, name="borrow_list_id"),
    path('edit-borrow/<int:pk>', views.edit_borrow, name="edit_borrow"),
    path('update-borrow/<int:pk>', views.update_borrow, name="update_borrow"),
    path('delete-borrow/<int:pk>', views.delete_borrow, name="delete_borrow"),
    # path('pdf/', views.GeneratePdf.as_view(), name="pdf"),
    # path('pdf/', views.render_pdf_view, name="pdf"),
]