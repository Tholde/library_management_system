import uuid
from io import BytesIO

from django.conf import settings
from django.template.loader import get_template
from xhtml2pdf import pisa


def save_pdf(params: dict):
    template = get_template("librarian/manage_book.html")
    html = template.render(params)
    response = BytesIO()
    pdf = pisa.pisaDocument(BytesIO(html.encode('UTF-8')), response)
    filename = uuid.uuid4()

    try:
        with open(str(settings.BASE_DIR) + f'/static/{filename}.pdf', 'wb+') as output:
            pdf = pisa.pisaDocument(BytesIO(html.encode('UTF-8')), output)

    except Exception as e:
        print(e)

    if pdf.err:
        return '', False
    return filename, True
