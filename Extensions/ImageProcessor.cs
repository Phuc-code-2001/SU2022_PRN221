﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ShinyTeeth.Extensions
{
	public class ImageProcessor 
	{

		public static string StorageDirectoryName = "images";
		public static string StorageRelativePath => Path.Combine("media", StorageDirectoryName);

		public static async Task<string> SaveToAsync(IWebHostEnvironment _environment, IFormFile File, string folderName)
		{
			if(!File.ContentType.StartsWith("image"))
            {
				return null;
            }


			string filename = $"{DateTime.Now.Ticks}_{File.FileName}";
			string RelativeURL = Path.Combine(StorageRelativePath, folderName, filename);
			var filepath = Path.Combine(_environment.WebRootPath, RelativeURL);


			var folder = Path.GetDirectoryName(filepath);
			if(!Directory.Exists(folder))
            {
				Directory.CreateDirectory(folder);
            }

			using (var fileStream = new FileStream(filepath, FileMode.Create))
			{
				await File.CopyToAsync(fileStream);
			}

			return $"/{RelativeURL}";
		}

		
	}
}
