using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class TTController : ApiController
    {
        DB_Model db = new DB_Model();

        [HttpGet]
        [Route("api/Select")]
        public List<tb_master> Select()
        {
            var sqlcmd = db.tb_master.OrderBy(x => x.MT_ID).ToList();
            return sqlcmd;
        }


        [HttpGet]
        [Route("api/SelectGetId/{MT_ID}")]
        public tb_master SelectGetId(int MT_ID)
        {
            var sqlcmd = db.tb_master.Where(x => x.MT_ID == MT_ID).FirstOrDefault();
            return sqlcmd;
        }


        [HttpPost]
        [Route("api/InsertTT")]
        public IHttpActionResult InsertTT(List<tb_master> list)
        {
            var status = false;
            var mes = "failed";

            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    db.tb_master.Add(new tb_master
                    {
                        MT_HN = list[i].MT_HN,
                        MT_Fname = list[i].MT_Fname,
                        MT_Lname = list[i].MT_Lname,
                        MT_Phone = list[i].MT_Phone,
                        MT_Email = list[i].MT_Email,
                    });
                }

                var rs = db.SaveChanges();
                if (rs > 0)
                {
                    status = true;
                    mes = "success";
                }

            }
            catch (Exception ex)
            {
                mes = ex.Message;
                // throw;
            }



            return Ok(new { status = status, mes = mes });
            //   return rs;
        }



       // [HttpPut]
        [AcceptVerbs("POST", "PUT")]
        [Route("api/updateTT")]
        public IHttpActionResult updateTT(tb_master model)
        {
            var status = false;
            var mes = "failed";

            try
            {
                var sqlcmd = db.tb_master.Where(x => x.MT_ID == model.MT_ID).FirstOrDefault();
                // sqlcmd.MT_HN = MT_HN;
                sqlcmd.MT_Fname = model.MT_Fname;
                sqlcmd.MT_Lname = model.MT_Lname;
                sqlcmd.MT_Phone = model.MT_Phone;
                sqlcmd.MT_Email = model.MT_Email;

                db.SaveChanges();
                var rs = db.SaveChanges();
                if (rs == 0)
                {
                    status = true;
                    mes = "success";
                }

                //   mes += rs.ToString();
            }
            catch (Exception ex)
            {
                mes = ex.Message;
                throw;
            }


            return Ok(new { status = status, mes = mes });
        }


        [HttpDelete]
        [Route("api/deleteTT/{MT_ID}")]
        public IHttpActionResult deleteTT(int MT_ID)
        {
            var status = false;
            var mes = "failed";

            try
            {
                var sqlcmd = db.tb_master.Where(x => x.MT_ID == MT_ID).SingleOrDefault();
                db.tb_master.Remove(sqlcmd);
                var rs = db.SaveChanges();

                if (rs == 1)
                {
                    status = true;
                    mes = "success";
                }
            }
            catch (Exception ex)
            {
                mes = ex.Message;
            }


            return Ok(new { status = status, mes = mes });
        }
    }
}
