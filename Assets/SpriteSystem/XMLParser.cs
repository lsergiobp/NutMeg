using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Xml;

/**
 * 
 * Classe Responsavel por interpretar e carregar o xml
 * 
**/ 
public class XMLParser {

	public static List<SpriteSheetInfo> Parse( TextAsset xml ) 
	{
		XmlReader reader = XmlReader.Create( new StringReader( xml.text ) );
		
		//variaveis para controle de dados
		Dictionary<string, SpriteRect> current = new Dictionary<string, SpriteRect>();
		string currentSpriteName = string.Empty;
		int currentRectInteration = 0;
		
		List<SpriteSheetInfo> info = new List<SpriteSheetInfo>();
		
		while( reader.Read() ) 
		{
			if( reader.IsStartElement( "sprite" ) )	
			{
				if( current.Count > 0 ) 
				{
					info.Add( new SpriteSheetInfo( current, currentSpriteName ) );
					currentRectInteration = 0;
					current = new Dictionary<string, SpriteRect>();
				}
				
				currentSpriteName = reader.GetAttribute( "name" );
			}
			else 
			{
				if( reader.IsStartElement( "rect" ) )
				{
					string rectName = reader.GetAttribute( "name" );
					
					if( string.IsNullOrEmpty( rectName ) ) 
						rectName = currentRectInteration.ToString();	
					
					string[] content = reader.ReadElementString().Split( ',' );
					
					current.Add( rectName, new SpriteRect( int.Parse( content[0] ),
															int.Parse( content[1] ),
															int.Parse( content[2] ),
															int.Parse( content[3] ) ) );
					
					currentRectInteration++;
				}
			}
		}
		
		if( current.Count > 0 ) 
			info.Add( new SpriteSheetInfo( current, currentSpriteName ) );
		
		reader.Close();
		
		return info;
	}
	
}
