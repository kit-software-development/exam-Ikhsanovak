using System;
using System.Windows.Forms;

namespace ClientApp.form
{
    internal static class Extensions
    {
        /*��� ��� ��������� ��� ��������� ���� ���� �������� �� �� UI ������, � ��������� ���� ����
        ����� � ������� UI ������, ������� ���� �����*/
        internal static void UI(this Form form, Action a)
        {
            form.Invoke(new MethodInvoker(a));
        }
    }
}