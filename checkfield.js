//TO CHECK dynamically fields' values

    function checkfield_alpha_num(id_pers, value) 
    {
        var regex = /^[-0-9 a-zA-Zיטחאגש . , ]+$|^()+$/;
       

       if(value!=null){
        if (regex.test(value) || value == ""){
            document.getElementById(id_pers).style.display = 'none';
            
            }
            else {        document.getElementById(id_pers).style.display = 'block';}
       }
    }


    function checkfield_alpha(id_pers, value) 
    {
        var regex = /^[-a-zA-Zיטחאגש ]+$/;

        if (value != null)
        {
            if (regex.test(value) || value == ""){
                document.getElementById(id_pers).style.display = 'none';
            }
        else { document.getElementById(id_pers).style.display = 'block';}    
        }
    }


    function checkfield_num(id_pers, value) 
    {
        var regex = /^[0-9]+(,[0-9]+)?$/;

        if (value != null)
        {
            if (regex.test(value) || value == "") { document.getElementById(id_pers).style.display = 'none'; }       
            else {document.getElementById(id_pers).style.display = 'block';}     
        }
    }
	

	

	    function checkfield_mail(id_pers, value) 
    {
        var regex = /^([\w\-.]+)@([a-zA-Z0-9\-.]+)$/;

        if (value != null)
        {
            if (regex.test(value) || value == "") { document.getElementById(id_pers).style.display = 'none'; }       
            else {document.getElementById(id_pers).style.display = 'block';}     
        }
    }

    