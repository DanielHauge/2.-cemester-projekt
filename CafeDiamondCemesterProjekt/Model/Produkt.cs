using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Produkt
{


    public Produkt(int id, int Pris, string Beskrivelse, string Pnavn)
    {
        // TODO: Complete member initialization
        this.Id = id;
        this.Pris = Pris;
        this.Beskrivelse = Beskrivelse;
        this.Pnavn = Pnavn;
    }
    private int Id
    {
        get;
        set;
    }
	private int Pris
	{
		get;
		set;
	}

    private string Beskrivelse
    {
        get;
        set;
    }
    private string Pnavn
    {
        get;
        set;
    }
    private int Type
    {
        get;
        set;
    }

    public override string ToString()
    {
        return string.Format("{0}: ID, Navn: {1}, Pris: {2}", Id, Pnavn, Pris);
    }
}

