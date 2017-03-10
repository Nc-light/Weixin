namespace GZH.Agent.Manager.Controllers.Agent.Response
{
    public class ResponseMsg
    {
        public static MsgEntity SetEntity(int returnCode, int statusCode)
        {
            MsgEntity r = new MsgEntity();

            //CURD
            switch (returnCode)
            {
                //Create
                case 1000:
                    r.returnCode = returnCode;
                    r.message = "添加成功";
                    r.statusCode = statusCode;
                    break;
                case 1100:
                    break;
            }

            return null;
        }
    }
}