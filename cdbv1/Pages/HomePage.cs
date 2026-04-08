using System;

namespace cdbv1.Pages;

public class HomePage() : Page
{
    public async Task Display()
    {
        await MainMenu();
    }
}