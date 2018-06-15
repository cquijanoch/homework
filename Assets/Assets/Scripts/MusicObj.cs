using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicObj : MonoBehaviour {

    private float columnX;
    private float columnY;
    private float columnZ;

    private float columnArtistHotness;
    private float columnTempo;
    private float columnFamiliarity;
    private float columnDuration;
    private float columnLoudness;
    private string columnTerms;
    private int columnMode;
    private float columnKey;
    private int columnYear;
    private string columnTitle;
    private string columnLocation;
    private string columnArtistName;
    private string columnReleaseName;
    private float columnSongHotness;

    private Color color;


    public float ColumnX { get { return columnX; } set { columnX = value; } }
    public float ColumnY { get { return columnY; } set { columnY = value; } }
    public float ColumnZ { get { return columnZ; } set { columnZ = value; } }

    public float ColumnArtistHotness { get { return columnArtistHotness; } set { columnArtistHotness = value; } }
    public float ColumnTempo { get { return columnTempo; } set { columnTempo = value; } }
    public float ColumnFamiliarity { get { return columnFamiliarity; } set { columnFamiliarity = value; } }
    public float ColumnDuration { get { return columnDuration; } set { columnDuration = value; } }
    public float ColumnLoudness { get { return columnLoudness; } set { columnLoudness = value; } }
    public string ColumnTerms { get { return columnTerms; } set { columnTerms = value; } }
    public int ColumnMode { get { return columnMode; } set { columnMode = value; } }
    public float ColumnKey { get { return columnKey; } set { columnKey = value; } }
    public int ColumnYear { get { return columnYear; } set { columnYear = value; } }
    public string ColumnTitle { get { return columnTitle; } set { columnTitle = value; } }
    public string ColumnLocation { get { return columnLocation; } set { columnLocation = value; } }
    public string ColumnArtistName { get { return columnArtistName; } set { columnArtistName = value; } }
    public string ColumnReleaseName { get { return columnReleaseName; } set { columnReleaseName = value; } }
    public float ColumnSongHotness { get { return columnSongHotness; } set { columnSongHotness = value; } }

    public Color Color { get; set; }


}
