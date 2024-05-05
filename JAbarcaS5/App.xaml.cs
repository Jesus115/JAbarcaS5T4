﻿namespace JAbarcaS5;

public partial class App : Application
{
	public static PersonRepository personRepo { get; set; } 
	public App(PersonRepository personRepository)
	{
		InitializeComponent();

		MainPage = new Vistas.ViPersona();
        personRepo= personRepository;
	}
}

