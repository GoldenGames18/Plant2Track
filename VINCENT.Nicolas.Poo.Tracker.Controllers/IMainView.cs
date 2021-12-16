using System;
using System.Collections.Generic;


namespace VINCENT.Nicolas.Poo.Tracker.Controllers
{
    public interface IMainView
    {
        event EventHandler<List<string>> Filter;
        event EventHandler<List<string>> Graph;

    }
}
