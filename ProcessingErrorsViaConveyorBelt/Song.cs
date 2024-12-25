namespace ProcessingErrorsViaConveyorBelt
{
	public class Song
	{
		public string? Name { get; set; }
		public string? Singer { get; set; }
		public string? RelYear { get; set; }
		public string? Text { get; set; }
		public Song(string? name, string? singer, string? relYear,
			string? text)
		{
			this.Name = name;//название песни
			this.Singer = singer;//исполнитель
			this.RelYear = relYear;//год выпуска
			this.Text = text;//текст песни
		}
		public override string? ToString() { return this.Name + ", " + this.Singer +
				", " + this.RelYear + ", " +
				this.Text; }
	}
}