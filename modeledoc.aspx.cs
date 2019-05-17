using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.IO;

public partial class modeledoc : System.Web.UI.Page
{
	protected string[] fileList;
	protected string[] subDirList;
	protected string dir = "reseau_documents";
	private Regex regex = new Regex("[-_]");
	
	
    protected void Page_Load(object sender, EventArgs e)
    {
	    Membre member = (Membre)Session["Membre"];
        if (member == null || (member.STATUT != "ultranego" && member.STATUT!="nego"))
        {
            Response.Redirect("./recherche.aspx");
        }
		
		if (Request.QueryString["type"] == "doc")
			dir = "reseau_documents";
		if (Request.QueryString["type"] == "lettres")
			dir = "reseau_lettres";
		
		((Label)Page.Master.FindControl("titrebandeau")).Text = "Modèles de documents";
		
    }
	
	//Affiche la liste des dossiers, fichiers de ces dossiers, et fichiers de ../reseau_document/ ou ../reseau_lettre
	//Appel recursive pour parcourir les sous dossiers
	//Profondeur est la profondeur de sous dossier, utilise pour faire un decalage sur la gauche
	protected void displayDir(string path = "", int profondeur = 0)
	{
		string[] subDirList = getSubDirectories(path);
		foreach(string subDir in subDirList)
		{
			string[] dirPath = subDir.Split('\\');
			string dirName = dirPath[dirPath.Length - 1];
			
			if(profondeur == 0)
				Response.Write("<tr profondeur='0'><td colspan='3'><span class='plusminusP cursor_link'>+</span> <img class='icon32' src='../img_site/folder32.png' alt='Dossier'> " + dirName + "</td></tr>");
			else
				Response.Write("<tr style='display:none' profondeur='"+profondeur+"'><td style='padding-left:" + (profondeur*40) + "px'><span class='plusminusP cursor_link'>+</span> <img class='icon32' src='../img_site/folder32.png' alt='Dossier'> " + dirName + "</td></tr>");
				
			displayDir(subDir, profondeur+1);
		}
		displayFiles(path, profondeur);
	}
	
	protected void displayFiles(string path = "", int profondeur = 0)
	{
		FileInfo[] fileList = getFiles(path);
		if(profondeur == 0)
			Response.Write("<tr profondeur='0'><td colspan='3'>");
		else
			Response.Write("<tr style='display:none' profondeur='"+profondeur+"'><td colspan='3'>");
		
		Response.Write("<table style='float:left;margin:auto;line-height:40px;padding-left:" + (profondeur*40) + "px'>");
		
		if(fileList.Length == 0)
			Response.Write("<tr><td class='italic'>Vide</td></tr>");
		else
		{
			foreach(FileInfo fileInfo in fileList)
			{
				string filePath = fileInfo.FullName.Split(new string[] {dir+"\\"}, StringSplitOptions.RemoveEmptyEntries)[1];
				//string[] pathSplit = filePath.Split('\\');
				string fileName = fileInfo.Name;
				//FileInfo info = new FileInfo(MapPath("../" + dir + "/" +filePath));
				if(profondeur == 0)
					Response.Write("<tr><td>");
				else
					Response.Write("<tr><td style='margin-left:-64px'><img class='icon32' src='../img_site/dirFileList.gif' alt=''>");
				Response.Write
				(
					
						"<a href='../" + dir + "/" + Uri.EscapeDataString(filePath) + "' style='color:initial;'><img class='icon32' src='../img_site/download.png' alt='Télécharger' title='Télécharger'> "
					+	regex.Replace(fileName," ") + "</a></td>"
					+ "<td class='md_poids'>" + Math.Ceiling((float)fileInfo.Length / 1024) + " Ko</td>"
					+ "<td class='md_poids'>" + fileInfo.LastWriteTime.ToString("d") + " </td>"
					+"</tr>"
				);
			}
		}
		Response.Write("</table>");
		Response.Write("</td></tr>");
	}
	
	
	protected string[] getSubDirectories(string path = "")
	{
		string[] fileList = System.IO.Directory.GetDirectories(MapPath("../"+dir + "/" + path));
		for(int i = 0 ; i < fileList.Length ; i++)
		{
			string[] temp = fileList[i].Split(new string[] {dir+"\\"}, StringSplitOptions.RemoveEmptyEntries);
			fileList[i] = temp[temp.Length - 1];
		}
		return fileList;
	}
	
	protected FileInfo[] getFiles(string path = "")
	{
		FileInfo[] fileList2 = new DirectoryInfo(MapPath("../"+dir + "/" + path)).GetFiles();
		
		//Tri par ordre decroissant de la date derniere modification
		for(int i = 0; i<fileList2.Length ; i ++)
		{
			int z = i;
			FileInfo temp = fileList2[i];
			for(int j = i; j<fileList2.Length ; j ++)
			{
				if(fileList2[j].LastWriteTime > temp.LastWriteTime)
				{
					z = j;
					temp = fileList2[j];
				}
			}
			fileList2[z] = fileList2[i];
			fileList2[i] = temp;
			
		}
		
		return fileList2;
		/*
		string[] fileList = System.IO.Directory.GetFiles(MapPath("../"+dir + "/" + path));
		for(int i = 0 ; i < fileList.Length ; i++)
		{
			string[] temp = fileList[i].Split(new string[] {dir+"\\"}, StringSplitOptions.RemoveEmptyEntries);
			fileList[i] = temp[temp.Length - 1];
		}
		return fileList;*/
	}
}
