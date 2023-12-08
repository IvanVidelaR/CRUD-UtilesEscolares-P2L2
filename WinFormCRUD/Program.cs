namespace WinFormCRUD
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Login FormLogin = new Login();
            FormLogin.ShowDialog();

            if(FormLogin.DialogResult == DialogResult.OK)
            {
                FormBienvenida formBienvenida = new FormBienvenida(FormLogin.Usuario);
                formBienvenida.ShowDialog();
                if(formBienvenida.DialogResult == DialogResult.OK)
                {
                    Application.Run(new FormPrincipal(FormLogin.Usuario, DateTime.Now));
                }
            }
        }
    }
}