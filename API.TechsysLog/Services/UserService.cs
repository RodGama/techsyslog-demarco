﻿using API.TechsysLog.Domain;
using API.TechsysLog.Models;
using API.TechsysLog.Repositories;
using API.TechsysLog.Repositories.Interfaces;
using API.TechsysLog.Services.Interfaces;
using API.TechsysLog.Validations;
using API.TechsysLog.ViewModel;
using FluentValidation;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace API.TechsysLog.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<UserViewModel> _userValidation;


        public UserService(IUserRepository userRepository, IValidator<UserViewModel> userValidation)
        {
            _userRepository = userRepository;
            _userValidation = userValidation;
        }
        public void Add(UserViewModel userViewModel)
        {
            var user = new User(userViewModel.Name, userViewModel.Email, BCryptor.Encrypt(userViewModel.Password).ToString(), userViewModel.Role);

            _userRepository.Add(user);
        }

        public AuthResult AuthUser(AuthViewModel authViewModel)
        {
            var result = new AuthResult();
            result.IsValid = false;
            result.Errors = new List<string>();
            var user = _userRepository.GetUserByEmailAndPassword(authViewModel.Email, authViewModel.Password);
            if (user != null)
            {
                if (BCryptor.InputIsCorrect(authViewModel.Password, user.Password))
                {
                    result.User = user;
                    result.IsValid = true;
                }
                else
                    result.Errors.Add("Senha incorreta");

            }
            else 
                result.Errors.Add("Cadastro não encontrado");
            return result;
        }

        public List<User> Get(int PageNumber, int pageQuantity)
        {
            return _userRepository.Get(PageNumber, pageQuantity);
        }

        public bool UserCreationIsValid(UserViewModel userViewModel, Result result)
        {

            var resultValidation = _userValidation.Validate(userViewModel);
            if (!resultValidation.IsValid)
            {
                foreach (var error in resultValidation.Errors)
                {
                    result.Errors.Add(error.ErrorMessage);
                }

                return false;
            }
            result.Success = true;
            return true;
        }
    }
}
