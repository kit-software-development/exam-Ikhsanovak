using System;
using System.Windows.Forms;

namespace ClientApp.form
{
    internal static class Extensions
    {
        /*так как сообщения для изменения поля игры приходят не из UI потока, а обновлять поле игры
        нужно в главном UI потоке, создаем этот метод*/
        internal static void UI(this Form form, Action a)
        {
            form.Invoke(new MethodInvoker(a));
        }
    }
}