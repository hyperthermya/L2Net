namespace L2_login
{
    public class SystemMsg : BaseText
    {
        public string Message = "";
        public uint Group = 0;
        public uint Red = 0;
        public uint Green = 0;
        public uint Blue = 0;
        public string SubMessage = "";
        public string Type = "";

        public void Clear()
        {
            ID = 0;
            Message = "";
            Group = 0;
            Red = 255;
            Green = 255;
            Blue = 255;
            SubMessage = "";
            Type = "";
        }

        public void Parse(string inp)
        {
            int pipe = 0, oldpipe = 0;
            //ID
            pipe = inp.IndexOf('|', oldpipe);
            if (pipe == -1) { return; }
            ID = Util.GetUInt32(inp.Substring(oldpipe, pipe - oldpipe));
            oldpipe = pipe + 1;
            //Message
            pipe = inp.IndexOf('|', oldpipe);
            if (pipe == -1) { return; }
            Message = inp.Substring(oldpipe, pipe - oldpipe);
            oldpipe = pipe + 1;
            //Group
            pipe = inp.IndexOf('|', oldpipe);
            if (pipe == -1) { return; }
            Group = Util.GetUInt32(inp.Substring(oldpipe, pipe - oldpipe));
            oldpipe = pipe + 1;
            //Blue 0
            pipe = inp.IndexOf('|', oldpipe);
            if (pipe == -1) { return; }
            Blue = byte.Parse(inp.Substring(oldpipe, pipe - oldpipe), System.Globalization.NumberStyles.HexNumber);
            oldpipe = pipe + 1;
            //Green 1
            pipe = inp.IndexOf('|', oldpipe);
            if (pipe == -1) { return; }
            Green = byte.Parse(inp.Substring(oldpipe, pipe - oldpipe), System.Globalization.NumberStyles.HexNumber);
            oldpipe = pipe + 1;
            //Red 2
            pipe = inp.IndexOf('|', oldpipe);
            if (pipe == -1) { return; }
            Red = byte.Parse(inp.Substring(oldpipe, pipe - oldpipe), System.Globalization.NumberStyles.HexNumber);
            oldpipe = pipe + 1;
            //SubMessage
            pipe = inp.IndexOf('|', oldpipe);
            if (pipe == -1) { return; }
            SubMessage = inp.Substring(oldpipe, pipe - oldpipe);
            oldpipe = pipe + 1;
            //Type
            if (oldpipe > inp.Length) { return; }
            Type = inp.Substring(oldpipe, inp.Length - oldpipe);
        }

        public string Get_Output(string msg1, string msg2, string msg3, string msg4, string msg5)
        {
            //
            string outs = Message;

            outs = outs.Replace("$s1", msg1);
            outs = outs.Replace("$s2", msg2);
            outs = outs.Replace("$s3", msg3);
            outs = outs.Replace("$s4", msg4);
            outs = outs.Replace("$s5", msg5);

            outs = outs.Replace("$S1", msg1);
            outs = outs.Replace("$S2", msg2);
            outs = outs.Replace("$S3", msg3);
            outs = outs.Replace("$S4", msg4);
            outs = outs.Replace("$S5", msg5);

            outs = outs.Replace("$c1", msg1);
            outs = outs.Replace("$c2", msg2);
            outs = outs.Replace("$c3", msg3);
            outs = outs.Replace("$c4", msg4);
            outs = outs.Replace("$c5", msg5);

            outs = outs.Replace("$C1", msg1);
            outs = outs.Replace("$C2", msg2);
            outs = outs.Replace("$C3", msg3);
            outs = outs.Replace("$C4", msg4);
            outs = outs.Replace("$C5", msg5);

            return outs;
        }
    }//end of systemmsg
}
