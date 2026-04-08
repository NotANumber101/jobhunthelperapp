using System;
using cdbv1.Models;
using Spectre;
using Spectre.Console;
using cdbv1.Helpers;
using Npgsql;
using Microsoft.Extensions.Logging;

namespace cdbv1.Pages;




public class HomePage() : Page
// public interface IPage()

{
    public async Task Display()
    {
        await MainMenu();
    }
        
    
}