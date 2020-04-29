using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

public class SaveData : MonoBehaviour
{
    public static SaveData self;
    private void Awake() {
        self = this;
    }

    public void Save(PlayerData data){
        
        XmlSerializer serializer = new XmlSerializer(typeof(PlayerData));
        StreamWriter writer = new StreamWriter("PlayerData.xml");
        serializer.Serialize(writer.BaseStream, data);
        writer.Close();
    }
}
