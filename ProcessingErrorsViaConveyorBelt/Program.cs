namespace ProcessingErrorsViaConveyorBelt
{
	public class Program
	{
		public async static Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			Song song1 = new Song("song1", "singer1", "1999",
				"song1 text"), song2 = new Song("song2", "singer2", "2002",
				"song2 text"), song3 = new Song("song3", "singer3", "2005",
				"song3 text");//создание песен
			Song[] songs = { song1, song2, song3 };//массив песен
			using (StreamWriter streamWriter = new StreamWriter("песни.txt", true)) foreach (Song singing in songs) await streamWriter.WriteLineAsync(singing.ToString());
			// Add services to the container.
			builder.Services.AddControllersWithViews();

			var app = builder.Build();

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=ProcessingErrors}/{action=Processing}/{id?}");
			app.MapGet("/", () => songs);
			app.Run();
		}
	}
}