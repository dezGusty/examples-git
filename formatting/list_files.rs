use std::error::Error;
use std::path::Path;

fn main() -> Result<(), Box<dyn Error>> {
	let dir_path = ".";
	let path = Path::new(dir_path);
	for file_res in path.read_dir()? {
		let file = file_res?;
		println!("File: {}", file.file_name().to_string_lossy());
	}

	Ok(())
}
