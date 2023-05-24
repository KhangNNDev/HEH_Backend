using Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class UserModel 
    {
        public Guid Id { get; set; }
        public string? phoneNumber { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string? image { get; set; }
        public DateTime dob { get; set; }
        public bool gender { get; set; }
        public Guid? roleID { get; set; }
        public  Role? Role { get; set; }
        //public virtual string Email { get; set; }
        public bool banStatus { get; set; }
    }
    public class UserCreateModel
    {

     
        public string userName { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string firstName { get; set; }

        public string? lastName { get; set; }
        [Required]
        public string address { get; set; }
        
        public string? image { get; set; }

        public DateTime dob { get; set; }
        public string phoneNumber { get; set; }
        [Required]
        public bool gender { get; set; } = true;
        public bool? bookingStatus { get; set; }
        public bool banStatus { get; set; }
    }
    public class MemberCreateModel
    {


        public string userName { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string firstName { get; set; }
        
        public string? lastName { get; set; }
        public string address { get; set; }
        
        public string? image { get; set; }
        [Required]
        public DateTime dob { get; set; }
        [Required]
        public string phoneNumber { get; set; }
        
        public bool gender { get; set; } = true;
        public bool? bookingStatus { get; set; }
        
    }
    public class UserUpdateModel
    {
        public Guid Id { get; set; }
        public string firstName { get; set; }
        public string? lastName { get; set; }
        public string address { get; set; }
        public string? image { get; set; }
        public DateTime dob { get; set; }
        public bool gender { get; set; } = true;
        public string PhoneNumber { get; set; }
        public bool? bookingStatus { get; set; }
       

    }
    public class BannedUserModel
    {
        public Guid Id { get; set; }
        public bool banStatus { get; set; }

    }
    public class UserUpdatePasswordModel
    {
        public Guid Id { get; set; }
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
    }
    public class UserUpdatePhoneModel
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        
    }
    public class LoginModel
    {
        public string Email { get; set; }
        public string password { get; set; }
    }

    public class ResetPasswordModel
    {
        public string email { get; set; }
        public string token { get; set; }
        public string newPassword { get; set; }
    }
}