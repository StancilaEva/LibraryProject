import { TextField, Box, Autocomplete, Stack, RadioGroup, FormControlLabel, Radio,IconButton,Button } from "@mui/material";
import { useEffect, useState } from "react";
import { UseFormHandleSubmit, register, errors, useForm } from "react-hook-form";
import { createComicBook, getGenres } from "../../services/ComicBooksService";
import ApplicationMenuBar from "../Cards/ApplicationMenuBar";
import { PhotoCamera } from "@mui/icons-material";
import { uploadFile } from "../../services/FileService";
import { Controller } from "react-hook-form";
import { comicBookSchema } from "../../validators/comicBookSchema";
import { joiResolver } from "@hookform/resolvers/joi";
import { useNavigate } from "react-router";

const AddComicBookPage = () => {
    const { register, formState: { errors },handleSubmit,control,setValue } = useForm({
        resolver: joiResolver(comicBookSchema),
    })
    const navigate = useNavigate()
    const [genres, setGenres] = useState([""])
    const [imageCover,SetImageCover] = useState("")
    register("cover")

    const loadFilterGenres = async () => {
        const genresResponse = await getGenres()
        genresResponse.genres.shift()
        setGenres(genresResponse.genres)
    }
    
    const createComic = async (data) =>{
        const comic = {
            title:data.title,
            publisher:data.publisher,
            cover:data.cover,
            issueNumber:data.issueNumber,
            genre:data.genre
        }
        const response = await createComicBook(comic)
        if(response.status==201){
            navigate(`/ComicBook/${response.comic.id}`)
        }
        else if(response.status===401 || response.status===403){
            navigate('/Login')
        }
    }

    useEffect(() => { loadFilterGenres() }, [])

    const uploadImage = async (e) =>{
        const files = e.target.files
        const formData = new FormData()
        let file = files[0]
        formData.append('formFile', file);

        const headers = new Headers();

        const response = await uploadFile(formData)
        if(response.status===200){
        SetImageCover(response.cover)
        setValue("cover",response.cover)
        }
        else if(response.status===401 || response.status===403){
            navigate('/Login')
        }
    }

    return (
        <Box>
            <ApplicationMenuBar />
            <Box component="form" sx={{ display: "flex", flexDirection: "column", alignItems: "center", overflow: 'auto' }} >

                <TextField
                    required
                    {...register("title")}
                    sx={{ width: 200, marginBottom: 1, marginTop: 2 }}
                    label="Title"
                    helperText={errors ? errors.title?.message : null}>
                </TextField>
                <TextField
                    required
                    {...register("issueNumber")}
                    sx={{ width: 200, marginBottom: 1 }}
                    label="Issue Number"
                    type="number"
                    inputProps={{ min: 0, inputMode: 'numeric', pattern: '[0-9]*' }}
                    helperText={errors ? errors.issueNumber?.message : null}>
                </TextField>
                <TextField
                    required
                    {...register("publisher")}
                    sx={{ width: 200, marginBottom: 1 }}
                    helperText={errors ? errors.publisher?.message : null}
                    label="Publisher">
                </TextField>
                <Controller
                    name="genre"
                    rules={{ required: true }}
                    control={control}
                    render={({ field }) =>
                <RadioGroup
                    aria-labelledby="demo-radio-buttons-group-label"
                    name="genre"
                    label="genre"
                    {...field}>
                    {
                        genres.map((genre) => { return <FormControlLabel key={genre} value={genre} control={<Radio />} label={genre} /> })
                    }
                </RadioGroup>}/>
                <IconButton color="primary" aria-label="upload picture" component="label">
                    <input hidden type="file" onChange={uploadImage}/>
                    <PhotoCamera />
                </IconButton>
                <Box
                component="img"
                src={imageCover}
                sx={{ objectFit: 'contain', maxHeight: '40vh' }}
                />
                <Button variant="outlined" onClick={handleSubmit(createComic)} sx={{ marginBottom: 1 }}>
                Submit
            </Button>
            </Box>
        </Box>
    )
}
export default AddComicBookPage;