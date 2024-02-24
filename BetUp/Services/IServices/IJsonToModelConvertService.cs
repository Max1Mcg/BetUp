﻿using BetUp.Models;
using Newtonsoft.Json.Linq;

namespace BetUp.Services.IServices
{
    public interface IJsonToModelConvertService
    {
        //сделать 2 разных метода, этот будет только инкапсулировать вызов нужного в зависимости от параметров
        public void FillMatchModel(ref MatchModel jsonResult, JArray jsonArray = null!, JObject jsonObject = null!);
    }
}
