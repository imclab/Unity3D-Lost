/*
================================================================================
FileName    : 
Description : 
Date        : 2014-05-22
Author      : Linkrules
Version     : 1.1
================================================================================
*/
using UnityEngine;
using System.Collections;
using System.IO;
using System.Security.Cryptography;
using System.Xml;
using System.Text;
using System;

public class DataCenter {

    public delegate void DataLoadFinished( string data );

    /// <summary>
    /// 从文件中读取二进制数据流,先读取前两个字节,为整个数据的长度,然后根据长度读取整个数据.
    /// </summary>
    /// <param name="path"></param>
    /// <returns>Success: 读取的数据, False: null</returns>
    static public byte[] LoadDataFromBinaryFile( string path ) {
        if ( !File.Exists( path ) ) {
            Debug.LogError( "File Not exist!!" );
            return null;
        }

        BinaryReader reader = new BinaryReader( File.Open( path, FileMode.Open, FileAccess.Read ) );
        int dataLength = reader.ReadInt16();

        byte[] data = new byte[dataLength];
        reader.Read( data, 0, dataLength );
        reader.Close();

        return data;
    }


    /// <summary>
    /// 将二进制数据流写入到指定的文件中,如果文件已经存在,则会被覆盖,数据流前两个字节为整个数据流的长度
    /// </summary>
    /// <param name="path"></param>
    /// <param name="data"></param>
    static public void SaveDataToBinaryFile( string path, byte[] data ) {
        BinaryWriter writer = new BinaryWriter( File.Open( path, FileMode.Create, FileAccess.Write ) );
        writer.Write( data );
        writer.Close();
    }


    /// <summary>
    /// Load file from streammingAssetsPath by StreamReader
    /// </summary>
    /// <param name="path"></param>
    /// <param name="fileName"></param>
    /// <param name="isEncrypted"></param>
    /// <returns></returns>
    static public string LoadDataFromFile( string path, string fileName, bool isEncrypted ) {
        path += fileName;
        if ( !File.Exists( path ) ) {
            Debug.Log( path + " Does not exists!" );
            return null;
        }

        StreamReader reader = File.OpenText( path );
        string data = reader.ReadToEnd();

        if ( isEncrypted ) {
            data = DecryptData( data );
        }

        return data;
    }


    /// <summary>
    /// Load file from streammingAssetsPath by StreamReader , but that is using Coroutine
    /// </summary>
    /// <param name="path"></param>
    /// <param name="fileName"></param>
    /// <param name="isEncrypted"></param>
    /// <param name="callback"></param>
    /// <returns></returns>
    static public IEnumerator LoadDataFromFile( string path, string fileName, bool isEncrypted, DataLoadFinished callback ) {
        path += fileName;

        string data = null;

        if ( File.Exists( path ) ) {
            StreamReader reader = File.OpenText( path );
            data = reader.ReadToEnd();
            if ( isEncrypted ) {
                data = DecryptData( data );
            }
        }

        if ( callback != null ) {
            callback( data );
        }

        yield return null;
    }


    /// <summary>
    /// Load data from Resources folder by TextAsset and using Coroutine
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="isEncrypted"></param>
    /// <param name="callback"></param>
    /// <returns></returns>
    static public IEnumerator LoadDataFromResources( string fileName, bool isEncrypted, DataLoadFinished callback ) {
        TextAsset textAsset = (TextAsset)Resources.Load( fileName );
        
        string finalData = null;
        if ( isEncrypted ) {
            finalData = DecryptData( textAsset.text );
        } else {
            finalData = textAsset.text;
        }

        callback( finalData );
        yield return null;
    }

    /// <summary>
    /// load data from Resources folder
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="isEncrypted"></param>
    /// <returns></returns>
    static public string LoadDataFromResources( string fileName, bool isEncrypted ) {
        TextAsset textAsset = (TextAsset)Resources.Load( fileName );

        string finalData = null;
        if ( isEncrypted ) {
            finalData = DecryptData( textAsset.text );
        } else {
            finalData = textAsset.text;
        }

        return finalData;
    }


    /// <summary>
    /// Save data to file , you can save to streammingAssets or Resources folder
    /// </summary>
    /// <param name="data"></param>
    /// <param name="path"></param>
    /// <param name="fileName"></param>
    /// <param name="isEncrypt"></param>
    static public void SaveDataToFile( string data, string path, string fileName, bool isEncrypt ) {
        if ( !Directory.Exists( path ) ) {
            Directory.CreateDirectory( path );
        }

        if ( isEncrypt ) {
            data = EncryptData( data );
        }

        path += fileName;

        if ( File.Exists( path ) ) {
            File.Delete( path );
        }


        StreamWriter writer = File.CreateText( path );
        writer.Write( data );
        writer.Close();
    }


    static private string key = "85645856963214585748596325412568";
    /// <summary>
    /// EncryptData
    /// </summary>
    /// <param name="plainText"></param>
    /// <returns></returns>
    static public string EncryptData( string plainText ) {
        byte[] keyArray = UTF8Encoding.UTF8.GetBytes( key );
        RijndaelManaged rDel = new RijndaelManaged();
        rDel.Key = keyArray;
        rDel.Mode = CipherMode.ECB;
        rDel.Padding = PaddingMode.PKCS7;
        ICryptoTransform cTransform = rDel.CreateEncryptor();

        byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes( plainText );
        byte[] resultArray = cTransform.TransformFinalBlock( toEncryptArray, 0, toEncryptArray.Length );

        return Convert.ToBase64String( resultArray, 0, resultArray.Length );
    }

    /// <summary>
    /// DecryptData
    /// </summary>
    /// <param name="cipherText"></param>
    /// <returns></returns>
    static public string DecryptData( string cipherText ) {
        byte[] keyArray = UTF8Encoding.UTF8.GetBytes( key );

        RijndaelManaged rDel = new RijndaelManaged();
        rDel.Key = keyArray;
        rDel.Mode = CipherMode.ECB;
        rDel.Padding = PaddingMode.PKCS7;
        ICryptoTransform cTransform = rDel.CreateDecryptor();

        byte[] toEncryptArray = Convert.FromBase64String( cipherText );
        byte[] resultArray = cTransform.TransformFinalBlock( toEncryptArray, 0, toEncryptArray.Length );

        return UTF8Encoding.UTF8.GetString( resultArray );

    }

}
