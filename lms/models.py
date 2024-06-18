from django.contrib.auth.hashers import make_password
from django.db import models
from django.utils import timezone


class Admin(models.Model):
    username = models.CharField(max_length=100)
    email = models.CharField(max_length=150)
    password = models.CharField(max_length=150)

    def __str__(self):
        return self.username


class Member(models.Model):
    firstname = models.CharField(max_length=150)
    lastname = models.CharField(max_length=150)
    address = models.CharField(max_length=150)
    mail = models.CharField(max_length=150)
    password = models.CharField(max_length=150)
    created_date = models.DateTimeField()
    updated_date = models.DateTimeField(default=timezone.now)

    def __str__(self):
        return self.firstname

    class Meta:
        ordering = ['-id']


class Librarian(models.Model):
    firstname = models.CharField(max_length=150)
    lastname = models.CharField(max_length=150)
    address = models.CharField(max_length=150)
    mail = models.CharField(max_length=150)
    password = models.CharField(max_length=150)
    created_date = models.DateTimeField()
    updated_date = models.DateTimeField(default=timezone.now)

    def __str__(self):
        return self.firstname


class Book(models.Model):
    isbn = models.CharField('ISBN', max_length=13)
    title = models.CharField(max_length=300)
    author = models.CharField(max_length=300)
    pub_date = models.IntegerField()
    category = models.CharField(max_length=250)
    barcode = models.ImageField(blank=True, null=True, upload_to='barcode_image')
    is_borrowed = models.BooleanField(default=False)
    created_date = models.DateTimeField()
    updated_date = models.DateTimeField(default=timezone.now)

    def __str__(self):
        return self.isbn


class Borrow(models.Model):
    id_book = models.IntegerField()
    id_user = models.IntegerField()
    borrow_date = models.DateTimeField()
    return_date = models.DateTimeField()
    is_return = models.BooleanField(default=False)
    note = models.CharField(max_length=250, null=True, blank=True)
    updated_date = models.DateTimeField(default=timezone.now)
