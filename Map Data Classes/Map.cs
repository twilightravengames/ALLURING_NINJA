using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace AlluringNinja.Map_Data_Classes
{
    public class Map
    {
        List<BackgroundTileMap> backgroundTileList = new List<BackgroundTileMap>();


        public void addBackgroundTile(BackgroundTileMap backgroundTile)
        {
            backgroundTileList.Add(backgroundTile);
        }

        public List<BackgroundTileMap> getBackgroundTileList()
        {
            return backgroundTileList;
        }

        //this function loads the map data from file
        public void load(String fileName, RenderingEngine renderingEngine)
        {
            loadBackgroundTiles(renderingEngine);
        }
        public void loadBackgroundTiles(RenderingEngine renderingEngine)
        {

            //foreach...
            //read file data and convert to background tiles
            String tileType = "TEST_TILE"; //change to loaded type


            //actually assign position according to loaded values


            Vector2 screenPosition = new Vector2();
            screenPosition.X = (float)renderingEngine.getViewportUpperX();
            screenPosition.Y = (float)renderingEngine.getViewportUpperY();


            //System.Console.WriteLine(screenPosition.X + " " + screenPosition.Y);


            BackgroundTileMap backgroundTileMap = new BackgroundTileMap(tileType);


            backgroundTileMap.setObjectPosition(screenPosition);

            int ImageXSize = 320;
            int ImageYSize = 240;

            //will actually be loaded from file
            Vector2 scale = new Vector2();
            scale.Y = (screenPosition.Y + ImageYSize + renderingEngine.getViewportHeight()) / (screenPosition.Y + ImageYSize) - 1;
            scale.X = (screenPosition.X + ImageXSize + renderingEngine.getViewportWidth()) / (screenPosition.X + ImageXSize) - 1;


            //System.Console.WriteLine("SCALE: " + scale.X + " " + scale.Y);

            backgroundTileMap.setScale(scale);


            backgroundTileList.Add(backgroundTileMap);

        }

    }
}
