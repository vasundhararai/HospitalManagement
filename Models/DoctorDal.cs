using Microsoft.Data.SqlClient;
using System.Numerics;

namespace HospitalManagement.Models
{
    public class DoctorDal
    {
        public List<Doctor> GetDoctor(string connection)
        {
            List<Doctor> doctors = new List<Doctor>();
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblDoctorDetails", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Doctor obj = new Doctor();
                obj.DoctorId = dr["DoctorRegId"].ToString();
                obj.DoctorName = dr["FirstName"].ToString() + " " + dr["LastName"].ToString();
                obj.Gender = dr["Gender"].ToString();
                obj.DoctorEmail = dr["EmailId"].ToString();
                obj.MobileNo = dr["MobileNo"].ToString();
                obj.SpecializedIn = dr["SpecialistIn"].ToString();
                obj.City = dr["City"].ToString();
                obj.State = dr["State"].ToString();
                obj.Address = dr["Address"].ToString();
                obj.Zipcode = dr["Zipcode"].ToString();
                obj.DoctorPhoto = dr["DoctorPhotoPath"].ToString();
                obj.DoctorCertificate = dr["CertificatePath"].ToString();
                obj.ReviewVideo = dr["ReviewVideoPath"].ToString();
                doctors.Add(obj);
            }
            return doctors;
            con.Close();
        }

        //method for inserting register form data into database using sp 
        public void RegisterDoctor(SignUpDoctor newDoctor, string connection)
        {


            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("Insert into tblDoctorDetails(FirstName,LastName,Gender,EmailId,MobileNo,DoctorRegId,SpecialistIn,City,State,Address,ZipCode,DoctorPhotoPath,CertificatePath,ReviewVideoPath,Password,ConfirmPassword)  \r\n Values (@Firstname, @Lastname, @Gender,@Email,@Mobilenumber,@RegisteredId,@SpecialistIn,@City,@State,@Address,@Zipcode,@PhotoPath,@CertificatePath,@ReviewVideoPath,@Password,@ConfirmPwd) ", con);
                //cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramFName = new SqlParameter();
                paramFName.ParameterName = "@Firstname";
                paramFName.Value = newDoctor.Firstname;
                cmd.Parameters.Add(paramFName);

                SqlParameter paramLName = new SqlParameter();
                paramLName.ParameterName = "@Lastname";
                paramLName.Value = newDoctor.Lastname;
                cmd.Parameters.Add(paramLName);

                SqlParameter paramGender = new SqlParameter();
                paramGender.ParameterName = "@Gender";
                paramGender.Value = newDoctor.Gender;
                cmd.Parameters.Add(paramGender);

                SqlParameter paramMobileNo = new SqlParameter();
                paramMobileNo.ParameterName = "@MobileNumber";
                paramMobileNo.Value = newDoctor.MobileNumber;
                cmd.Parameters.Add(paramMobileNo);

                SqlParameter paramRegId = new SqlParameter();
                paramRegId.ParameterName = "@RegisteredId";
                paramRegId.Value = newDoctor.RegisteredId;
                cmd.Parameters.Add(paramRegId);

                SqlParameter paramSpecialization = new SqlParameter();
                paramSpecialization.ParameterName = "@SpecialistIn";
                paramSpecialization.Value = newDoctor.SpecialistIn;
                cmd.Parameters.Add(paramSpecialization);

                SqlParameter paramCity = new SqlParameter();
                paramCity.ParameterName = "@City";
                paramCity.Value = newDoctor.City;
                cmd.Parameters.Add(paramCity);

                SqlParameter paramState = new SqlParameter();
                paramState.ParameterName = "@State";
                paramState.Value = newDoctor.State;
                cmd.Parameters.Add(paramState);

                SqlParameter paramAddress = new SqlParameter();
                paramAddress.ParameterName = "@Address";
                paramAddress.Value = newDoctor.Address;
                cmd.Parameters.Add(paramAddress);

                SqlParameter paramZipcode = new SqlParameter();
                paramZipcode.ParameterName = "@Zipcode";
                paramZipcode.Value = newDoctor.Zipcode;
                cmd.Parameters.Add(paramZipcode);

                SqlParameter paramPhotoPath = new SqlParameter();
                paramPhotoPath.ParameterName = "@PhotoPath";
                paramPhotoPath.Value = newDoctor.UploadPhoto;
                cmd.Parameters.Add(paramPhotoPath);

                SqlParameter paramCertificatePath = new SqlParameter();
                paramCertificatePath.ParameterName = "@CertificatePath";
                paramCertificatePath.Value = newDoctor.UploadCertificate;
                cmd.Parameters.Add(paramCertificatePath);

                SqlParameter paramReviewVideoPath = new SqlParameter();
                paramReviewVideoPath.ParameterName = "@ReviewVideoPath";
                paramReviewVideoPath.Value = newDoctor.PatientReviewVideo;
                cmd.Parameters.Add(paramReviewVideoPath);

                SqlParameter paramEmail = new SqlParameter();
                paramEmail.ParameterName = "@Email";
                paramEmail.Value = newDoctor.Email;
                cmd.Parameters.Add(paramEmail);

                SqlParameter paramPassword = new SqlParameter();
                paramPassword.ParameterName = "@Password";
                paramPassword.Value = newDoctor.Password;
                cmd.Parameters.Add(paramPassword);

                SqlParameter paramConfirmPwd = new SqlParameter();
                paramConfirmPwd.ParameterName = "@ConfirmPwd";
                paramConfirmPwd.Value = newDoctor.ConfirmPassword;
                cmd.Parameters.Add(paramConfirmPwd);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }

}
