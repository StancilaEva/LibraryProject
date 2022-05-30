import { useEffect, useState } from "react"
import { Autocomplete } from "@mui/material"
import { getSearchComics } from "../../../services/ComicBooksService"
import { TextField } from "@mui/material"
import { Box } from "@mui/system"
import { useNavigate } from "react-router-dom"
import SearchIcon from '@mui/icons-material/Search';
const SearchComic = () =>{

    const [searchResult,setSearchResult] = useState([])
    const [searchString,setSearchString] = useState("")
    const navigate = useNavigate()

    const loadSearchResults = async () =>{
        const data = await getSearchComics(searchString)
        setSearchResult(data)
    }

    useEffect(()=>{loadSearchResults()},[searchString])

    return (
        <Autocomplete
        freeSolo
        onChange={(event,value)=>{
            if(value?.hasOwnProperty("id")){
            navigate(`/ComicBook/${value.id}`) 
            //aparent navigate daca sunt deja pe ruta /ComicBook/:id nu o sa modifice continutul paginii ci doar ruta
            // mai exista React Navigate si trebuie sa folosesc push in acest caz
            //pana atunci raman la solutia asta
            navigate(0)
            }
        }}
        options={searchResult}
        getOptionLabel={(option) => {
            if(option.hasOwnProperty("title"))
            {
            return `${option.title} Issue No ${option.issueNumber}`
            }
            else{
             return ``
            }
        }}
        renderOption={(props, option) => (
            <Box 
            component="li" 
            {...props}>
              {option.title} Issue No {option.issueNumber}
            </Box>
          )}
        renderInput={(params) =>
             <TextField {...params} label="Search Comics" 
             onChange={(evt,val)=>{setSearchString(evt.target.value)}}
             inputProps={{
                ...params.inputProps,
                autoComplete: 'new-password', 
              }}></TextField>}
        sx={{width:'20%'}}>
        </Autocomplete>
    )
}
export default SearchComic

//https://localhost:7015/api/ComicBooks/Search/