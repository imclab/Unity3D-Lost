using System.Collections.Generic;
using System.Collections;
using ID_MAP = System.String;
using JsonFx.Json;
using System;

namespace Com.Lost.GameData {
    [System.Serializable]
    public class GameConfigure {
        public GameConfigure() { }

        public SpaceFileItem[] SpaceMapMatrix = new SpaceFileItem[ConstantParams.spaceMatrixSize];
        public bool IsFirstGameTime;
        public SpaceFileItem nextSpace;
    }

    [System.Serializable]
    public class SpaceFileItem{
        public ID_MAP id;
        public string fileName;        
    }
    
}

