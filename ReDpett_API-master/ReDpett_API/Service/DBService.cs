using Microsoft.Data.SqlClient;
using ReDpett_API.Modal;
using System.Data;
using System.Xml.Linq;

namespace ReDpett_API.Service
{
    public class DBService : IDBService
    {
        public void InserTransaction(Projects _data, string _guid)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Server=tcp:testwebjob.database.windows.net,1433;Initial Catalog=TrackingMasterOLD;Persist Security Info=False;User ID=testadmin;" +
                    "Password=Password13!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                using (SqlCommand cmd = new SqlCommand("SpInsertProjectRecord"))
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@GlobalRecordId", SqlDbType.NVarChar, 255));
                    cmd.Parameters["@GlobalRecordId"].Value = _guid;

                    cmd.Parameters.Add(new SqlParameter("@RALevel", SqlDbType.Bit));
                    cmd.Parameters["@RALevel"].Value = 0;
                    cmd.Parameters.Add(new SqlParameter("@FETPFrontline", SqlDbType.NVarChar, 255));
                    cmd.Parameters["@FETPFrontline"].Value = _data.FETP == null ? DBNull.Value : _data.FETP;
                    cmd.Parameters.Add(new SqlParameter("@RPFL1_CohortNumber", SqlDbType.Float));
                    cmd.Parameters["@RPFL1_CohortNumber"].Value = _data.CohortNumber == null ? DBNull.Value : _data.CohortNumber;
                    cmd.Parameters.Add(new SqlParameter("@RPFL2_CohortStart", SqlDbType.DateTime));
                    cmd.Parameters["@RPFL2_CohortStart"].Value = _data.CohortStartDate == null ? DBNull.Value : _data.CohortStartDate;
                    cmd.Parameters.Add(new SqlParameter("@RPFL3_CohortEnd", SqlDbType.DateTime));
                    cmd.Parameters["@RPFL3_CohortEnd"].Value = _data.CohortEndDate == null ? DBNull.Value : _data.CohortEndDate;

                    cmd.Parameters.Add(new SqlParameter("@RPFL4_RosterNumber", SqlDbType.Float));
                    cmd.Parameters["@RPFL4_RosterNumber"].Value = 0;
                    cmd.Parameters.Add(new SqlParameter("@RPFL5_NameLast", SqlDbType.NVarChar, 4000));
                    cmd.Parameters["@RPFL5_NameLast"].Value = _data.Sur_LastName == null ? DBNull.Value : _data.Sur_LastName;
                    cmd.Parameters.Add(new SqlParameter("@RPFL6_NameFirst", SqlDbType.NVarChar, 4000));
                    cmd.Parameters["@RPFL6_NameFirst"].Value = _data.Given_FirstName == null ? DBNull.Value : _data.Given_FirstName;
                    cmd.Parameters.Add(new SqlParameter("@RPFL7_FullName", SqlDbType.NVarChar, 4000));
                    cmd.Parameters["@RPFL7_FullName"].Value = _data.ResidentName == null ? DBNull.Value : _data.ResidentName;
                    cmd.Parameters.Add(new SqlParameter("@RPFL8_Sex", SqlDbType.NVarChar, 255));
                    cmd.Parameters["@RPFL8_Sex"].Value = _data.Sex == null ? DBNull.Value : _data.Sex;
                    cmd.Parameters.Add(new SqlParameter("@RPFL_DateofBirth", SqlDbType.DateTime));
                    cmd.Parameters["@RPFL_DateofBirth"].Value = _data.DOB == null ? DBNull.Value : _data.DOB;
                    cmd.Parameters.Add(new SqlParameter("@RPFL9_Age", SqlDbType.Float));
                    cmd.Parameters["@RPFL9_Age"].Value = _data.Age < 0 ? DBNull.Value : _data.Age;
                    cmd.Parameters.Add(new SqlParameter("@RPFL10_Email", SqlDbType.NVarChar, 4000));
                    cmd.Parameters["@RPFL10_Email"].Value = _data.Email == null ? DBNull.Value : _data.Email;

                    cmd.Parameters.Add(new SqlParameter("@RPFL12_Employer", SqlDbType.NVarChar, 4000));
                    cmd.Parameters["@RPFL12_Employer"].Value = _data.Employer == null ? DBNull.Value : _data.Employer;

                    cmd.Parameters.Add(new SqlParameter("@RPFL11_ProBckgrd", SqlDbType.NVarChar, 255));
                    cmd.Parameters["@RPFL11_ProBckgrd"].Value = _data.Professional_Background == null ? DBNull.Value : _data.Professional_Background;

                    cmd.Parameters.Add(new SqlParameter("@RPFL11b_Other", SqlDbType.NVarChar, 4000));
                    cmd.Parameters["@RPFL11b_Other"].Value = DBNull.Value;
                    cmd.Parameters.Add(new SqlParameter("@RPFL14_YearJob", SqlDbType.Float));
                    cmd.Parameters["@RPFL14_YearJob"].Value = _data.YearsOnJob < 0 ? DBNull.Value : _data.YearsOnJob;

                    cmd.Parameters.Add(new SqlParameter("@RPFL13_JobTitle", SqlDbType.NVarChar, 4000));
                    cmd.Parameters["@RPFL13_JobTitle"].Value = _data.JobTitle == null ? DBNull.Value : _data.JobTitle;

                    cmd.Parameters.Add(new SqlParameter("@RPFL16_SupervisorName", SqlDbType.NVarChar, 4000));
                    cmd.Parameters["@RPFL16_SupervisorName"].Value = _data.SupervisorName == null ? DBNull.Value : _data.SupervisorName;
                    cmd.Parameters.Add(new SqlParameter("@RPFL20_Latitude", SqlDbType.Float));
                    cmd.Parameters["@RPFL20_Latitude"].Value = _data.RPFL20_Latitude == null ? DBNull.Value : _data.RPFL20_Latitude;

                    cmd.Parameters.Add(new SqlParameter("@RPFL21_Location", SqlDbType.NText));
                    cmd.Parameters["@RPFL21_Location"].Value = DBNull.Value;
                    cmd.Parameters.Add(new SqlParameter("@RPFL19_Longitude", SqlDbType.Float));
                    cmd.Parameters["@RPFL19_Longitude"].Value = _data.RPFL19_Longitude < 0 ? DBNull.Value : _data.RPFL19_Longitude;

                    cmd.Parameters.Add(new SqlParameter("@RPFL17_District", SqlDbType.NVarChar, 4000));
                    cmd.Parameters["@RPFL17_District"].Value = _data.City == null ? DBNull.Value : _data.City;

                    cmd.Parameters.Add(new SqlParameter("@RPFL18_Region", SqlDbType.NVarChar, 4000));
                    cmd.Parameters["@RPFL18_Region"].Value = _data.Country == null ? DBNull.Value : _data.Country;

                    cmd.Parameters.Add(new SqlParameter("@RPFL22_FacilityName", SqlDbType.NVarChar, 4000));
                    cmd.Parameters["@RPFL22_FacilityName"].Value = _data.FacilityName == null ? DBNull.Value : _data.FacilityName;

                    cmd.Parameters.Add(new SqlParameter("@RPFL23a_LevelFacility", SqlDbType.NVarChar, 255));
                    cmd.Parameters["@RPFL23a_LevelFacility"].Value = _data.FacilityLevel == null ? DBNull.Value : _data.FacilityLevel;

                    cmd.Parameters.Add(new SqlParameter("@RPFL23b_Other", SqlDbType.NVarChar, 4000));
                    cmd.Parameters["@RPFL23b_Other"].Value = DBNull.Value;

                    cmd.Parameters.Add(new SqlParameter("@RPFL15_SiteName", SqlDbType.NVarChar, 4000));
                    cmd.Parameters["@RPFL15_SiteName"].Value = DBNull.Value;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                }
                foreach (FileData data in _data.File_Att_Info)
                {
                    using (SqlConnection conn = new SqlConnection("Server=tcp:testwebjob.database.windows.net,1433;Initial Catalog=TrackingMasterOLD;Persist Security Info=False;User ID=testadmin;" +
                    "Password=Password13!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))

                    using (SqlCommand cmd = new SqlCommand("SpInsertAttachmentRecord"))
                    {
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.Add(new SqlParameter("@project_id", SqlDbType.NVarChar, 225));
                        cmd.Parameters["@project_id"].Value = _guid;

                        cmd.Parameters.Add(new SqlParameter("@file", SqlDbType.VarChar, int.MaxValue));
                        cmd.Parameters["@file"].Value = data.File_Att;

                        cmd.Parameters.Add(new SqlParameter("@FileName", SqlDbType.NVarChar, 225));
                        cmd.Parameters["@FileName"].Value = data.Att_FileName;

                        cmd.Parameters.Add(new SqlParameter("@fileContentType", SqlDbType.NVarChar, 225));
                        cmd.Parameters["@fileContentType"].Value = data.ContentType;

                        cmd.Parameters.Add(new SqlParameter("@fileSize", SqlDbType.NVarChar, 225));
                        cmd.Parameters["@fileSize"].Value = data.FileSize;

                        cmd.Parameters.Add(new SqlParameter("@reportTitle", SqlDbType.NVarChar, 225));
                        cmd.Parameters["@reportTitle"].Value = data.Report_Title;

                        cmd.Parameters.Add(new SqlParameter("@reportCategory ", SqlDbType.NVarChar, 225));
                        cmd.Parameters["@reportCategory "].Value = data.TypeOfReport;

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }

    }
}
