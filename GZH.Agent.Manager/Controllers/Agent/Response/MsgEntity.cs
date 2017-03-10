namespace GZH.Agent.Manager.Controllers.Agent.Response
{
    public class MsgEntity
    {
        public int returnCode { get; set; }

        public string message { get; set; }
    }

    public class ResponseMsg
    {
        public static MsgEntity SetEntity(out MsgEntity r,  int returnCode)
        {
            r = new MsgEntity();

            //CURD
            switch (returnCode)
            {
                //Create
                case 1000:
                    r.returnCode = returnCode;
                    r.message = "添加成功";
                    break;
                case 1100:
                    r.returnCode = returnCode;
                    r.message = "添加失败，记录已存在";
                    break;
                case 1101:
                    r.returnCode = returnCode;
                    r.message = "添加失败，记录写入出错";
                    break;
                case 1102:
                    r.returnCode = returnCode;
                    r.message = "添加失败，记录id异常";
                    break;

                //Update
                case 2000:
                    r.returnCode = returnCode;
                    r.message = "修改成功";
                    break;
                case 2100:
                    r.returnCode = returnCode;
                    r.message = "修改失败，记录不存在";
                    break;
                case 2101:
                    r.returnCode = returnCode;
                    r.message = "修改失败，记录写入出错";
                    break;

                //Del
                case 3000:
                    r.returnCode = returnCode;
                    r.message = "删除成功";
                    break;
                case 3100:
                    r.returnCode = returnCode;
                    r.message = "删除失败，记录不存在";
                    break;
                case 3101:
                    r.returnCode = returnCode;
                    r.message = "删除失败，记录写入出错";
                    break;
            }

            return r;
        }
    }
}