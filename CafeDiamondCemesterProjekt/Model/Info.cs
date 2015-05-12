using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Info
{
	public List<Event> Eventliste
    {
		get;
		set;
	}

	public List<Produkt> Sortiment
	{
		get;
		set;
	}

	public RedigeringsHandler RedigeringsHandler
	{
		get;
		set;
	}

	public void TilføjInfoElement()
	{
		//Endnu ikke implementeret
	}

	public void LæsInfoElementer()
	{
		//Endnu ikke implementeret.
	}

}

