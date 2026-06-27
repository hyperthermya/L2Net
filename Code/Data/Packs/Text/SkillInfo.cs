namespace L2_login
{
    public class SkillInfo
    {
        public uint ID = 0;
        public uint Level = 0;
        public string Name = "";
        public string Desc1 = "";
        public string Desc2 = "";
        public string Desc3 = "";

        public void Parse(string inp)
        {
            int pipe = 0, oldpipe = 0;
            //ID
            pipe = inp.IndexOf('|', oldpipe);
            if (pipe == -1)
            {
                ID = Util.GetUInt32(inp);
                Level = 0;
                Name = "";
                Desc1 = "";
                Desc2 = "";
                Desc3 = "";
                return;
            }
            ID = Util.GetUInt32(inp.Substring(oldpipe, pipe - oldpipe));
            oldpipe = pipe + 1;
            //Level
            pipe = inp.IndexOf('|', oldpipe);
            if (pipe == -1)
            {
                Level = Util.GetUInt32(inp.Substring(oldpipe, inp.Length - oldpipe));
                Name = "";
                Desc1 = "";
                Desc2 = "";
                Desc3 = "";
                return;
            }
            Level = Util.GetUInt32(inp.Substring(oldpipe, pipe - oldpipe));
            oldpipe = pipe + 1;
            //Name
            pipe = inp.IndexOf('|', oldpipe);
            if (pipe == -1)
            {
                Name = oldpipe <= inp.Length ? inp.Substring(oldpipe, inp.Length - oldpipe) : "";
                Desc1 = "";
                Desc2 = "";
                Desc3 = "";
                return;
            }
            Name = inp.Substring(oldpipe, pipe - oldpipe);
            oldpipe = pipe + 1;
            //Desc1
            pipe = inp.IndexOf('|', oldpipe);
            if (pipe == -1)
            {
                Desc1 = oldpipe <= inp.Length ? inp.Substring(oldpipe, inp.Length - oldpipe) : "";
                Desc2 = "";
                Desc3 = "";
                return;
            }
            Desc1 = inp.Substring(oldpipe, pipe - oldpipe);
            oldpipe = pipe + 1;
            //Desc2
            pipe = inp.IndexOf('|', oldpipe);
            if (pipe == -1)
            {
                Desc2 = oldpipe <= inp.Length ? inp.Substring(oldpipe, inp.Length - oldpipe) : "";
                Desc3 = "";
                return;
            }
            Desc2 = inp.Substring(oldpipe, pipe - oldpipe);
            oldpipe = pipe + 1;
            //Desc3
            Desc3 = oldpipe <= inp.Length ? inp.Substring(oldpipe, inp.Length - oldpipe) : "";
        }
    }
}
