using System.Drawing;

/// <summary>
/// Delegado que define un método que actualiza utilizando la fecha actual.
/// </summary>
/// <param name="fecha">Fecha actual.</param>
public delegate void DelegadoActualizar(DateTime fecha);
/// <summary>
/// Delegado que define un método que utiliza una imagen Bitmap.
/// </summary>
/// <param name="imagen">Imagen Bitmap.</param>
public delegate void DelegadoDeLaImagen(Bitmap imagen);
/// <summary>
/// Delegado utilizado para manejar la actualización de una barra de progreso y una etiqueta asociada.
/// </summary>
/// <typeparam name="T">Tipo del control de barra de progreso.</typeparam>
/// <typeparam name="U">Tipo del control de etiqueta asociada a la barra de progreso.</typeparam>
/// <param name="progressBar">Control de barra de progreso.</param>
/// <param name="label">Control de etiqueta asociada a la barra de progreso.</param>
public delegate void DelegadoBarraDeProgreso<T, U>(T progressBar, U label);
/// <summary>
/// Delegado utilizado en el proyecto de Windows Forms (FormLogin) para manejar eventos relacionados con la barra de progreso.
/// </summary>
public delegate void CredencialesIncorrectasEventHandler(object sender, EventArgs e);
/// <summary>
/// Delegado utilizado en el proyecto de Windows Forms (FormBienvenida) para manejar eventos relacionados con el progreso alcanzado.
/// </summary>
/// <param name="porcentaje">Porcentaje de progreso.</param>
public delegate void ProgresoAlcanzadoEventHandler(int porcentaje);
/// <summary>
/// Delegado utilizado en el proyecto de Windows Forms (FormLogin) para manejar evento de intentos superados.
/// </summary>
public delegate void IntentosSuperadosEventHandler(object sender, EventArgs e);