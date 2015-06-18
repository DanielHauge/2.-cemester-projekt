using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Event
{
    private int Id
    {
        get;
        set;
    }

	private string Overskrift
	{
		get;
		set;
	}

	private string Dato
	{
		get;
		set;
	}
    private string Beskrivelse
    {
        get;
        set;
    }

    public override string ToString()
    {
        return string.Format("{0}: ID, Overskrift: {1}, Dato: {2}", Id, Overskrift, Dato);
    }

    public Event(int id, string overskrift, string dato, string beskrivelse)
    {
        this.Id = id;
        this.Overskrift = overskrift;
        this.Dato = dato;
        this.Beskrivelse = beskrivelse;
    }
}

