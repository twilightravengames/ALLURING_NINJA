using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlluringNinja.Map_Data_Classes
{
    public class BackgroundTileMap : Thing2DMap
    {
        String tileType;

        public BackgroundTileMap(String tileType)
        {
            this.tileType = tileType;
        }

        public String getTileType()
        {
            return tileType;
        }
    }
}
