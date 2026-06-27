namespace L2_login
{
    public class HennaGroup : BaseText
    {
        //id|dye_id|name|symbol_add_name|added_type|added_amount|subtracted_type|subtracted_amount
        public uint DYE_ID = 0;
        public string Name = "";
        public string Icon = "";
        public string Add_Name = "";
        public string Add_Desc = "";

        public void Clear()
        {
            ID = 0;
            DYE_ID = 0;
            Name = "";
            Icon = "";
            Add_Name = "";
            Add_Desc = "";
        }

        public void Parse(string inp)
        {
            int pipe = 0, oldpipe = 0;
            //ID
            pipe = inp.IndexOf('|', oldpipe);
            if (pipe == -1) { return; }
            ID = Util.GetUInt32(inp.Substring(oldpipe, pipe - oldpipe));
            oldpipe = pipe + 1;
            //DYE_ID
            pipe = inp.IndexOf('|', oldpipe);
            if (pipe == -1) { return; }
            DYE_ID = Util.GetUInt32(inp.Substring(oldpipe, pipe - oldpipe));
            oldpipe = pipe + 1;
            //Name
            pipe = inp.IndexOf('|', oldpipe);
            if (pipe == -1) { Name = oldpipe <= inp.Length ? inp.Substring(oldpipe) : ""; return; }
            Name = inp.Substring(oldpipe, pipe - oldpipe);
            oldpipe = pipe + 1;
            //Icon
            pipe = inp.IndexOf('|', oldpipe);
            if (pipe == -1) { Icon = oldpipe <= inp.Length ? inp.Substring(oldpipe) : ""; return; }
            Icon = inp.Substring(oldpipe, pipe - oldpipe);
            oldpipe = pipe + 1;
            //Add_Name
            pipe = inp.IndexOf('|', oldpipe);
            if (pipe == -1) { Add_Name = oldpipe <= inp.Length ? inp.Substring(oldpipe) : ""; return; }
            Add_Name = inp.Substring(oldpipe, pipe - oldpipe);
            oldpipe = pipe + 1;
            //Add_Desc
            Add_Desc = oldpipe <= inp.Length ? inp.Substring(oldpipe) : "";
        }
    }//end of HennaGroup
}