import { useEffect } from "react"
import { MenuItem } from "@mui/material"
import { TextField } from "@mui/material"
import { useState } from "react"
import { getGenres } from "../../../services/ComicBooksService"

const GenreFilter = (props) =>{
    const {filterGenre,setFilterGenre,setPage} = props
    const [genres, setGenres] = useState([""])

    const loadFilterGenres = async () => {
        const genresResponse = await getGenres()
        setGenres(genresResponse.genres)
    }

    const onFilterGenreChange = (evt) => {
        const value = evt.target.value;
        setFilterGenre(value)
        setPage(1)
    }

    useEffect(()=>{loadFilterGenres()},[])

    return(
        <TextField 
            select
            label={"Genre"}
            value={filterGenre}
            onChange={onFilterGenreChange}
            sx={{margin:'4px',width:'10%'}}
        >
            {
                genres.map((option) => (
                    <MenuItem key={option} value={option}>
                        {option===""?"Empty":option}
                    </MenuItem>
                ))}
        </TextField>
    )
}

export default GenreFilter