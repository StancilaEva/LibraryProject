import { TextField, Box, MenuItem } from "@mui/material";
import { useState,useEffect } from "react";
import api from "../../api/posts"
import { getGenres,getPublishers } from "../../services/ComicBooksService";

function FilterHeader(props) {
    const {setSortOrder,sortOrder,setFilterGenre,
        setFilterPublisher,filterGenre,filterPublisher,setPage,sortOptions} = props

    const [genres, setGenres] = useState([""])
    const [publishers, setPublishers] = useState([""])


    const loadFilterData = async () => {
        const genresResponse = await getGenres()
        setGenres(genresResponse.genres)
        const publishersResponse = await getPublishers()
        setPublishers(publishersResponse.publishers)
    }

    const onSortChange = (evt) => {
        const value = evt.target.value;
        if (value === sortOptions[1].label) {
            setSortOrder(sortOptions[1]);
        }
        else {
            setSortOrder(sortOptions[0]);
        }
    }

    const onFilterPublisherChange = (evt) => {
        const value = evt.target.value;
        setFilterPublisher(value)
        setPage(1)
    }

    const onFilterGenreChange = (evt) => {
        const value = evt.target.value;
        setFilterGenre(value)
        setPage(1)
    }

    useEffect(() => { loadFilterData() }, [])

    return (<Box className="filters" sx={{ display: "flex", width: '100%' }}>
        <TextField
            id="outlined-select-currency"
            select
            label="Sort"
            value={sortOrder.label}
            onChange={onSortChange}
        >
            {
                sortOptions.map((option) => (
                    <MenuItem key={option.value} value={option.label}>
                        {option.label}
                    </MenuItem>
                ))}
        </TextField>
        <TextField
            select
            label={"Publisher"}
            value={filterPublisher}
            onChange={onFilterPublisherChange}
        >
            {
                publishers.map((option) => (
                    <MenuItem key={option} value={option}>
                        {option}
                    </MenuItem>
                ))}
        </TextField>
        <TextField
            select
            label={"Genre"}
            value={filterGenre}
            onChange={onFilterGenreChange}
        >
            {
                genres.map((option) => (
                    <MenuItem key={option} value={option}>
                        {option}
                    </MenuItem>
                ))}
        </TextField>
    </Box>)
}
export default FilterHeader;