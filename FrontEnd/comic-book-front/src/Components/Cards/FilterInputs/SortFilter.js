import { useEffect } from "react"
import { MenuItem } from "@mui/material"
import { TextField } from "@mui/material"
import { useState } from "react"
import { getGenres } from "../../../services/ComicBooksService"

const SortFilter = (props) =>{
    const {sortOrder,setSortOrder,sortOptions} = props

    const onSortChange = (evt) => {
        const value = evt.target.value;
        if (value === sortOptions[1].label) {
            setSortOrder(sortOptions[1]);
        }
        else {
            setSortOrder(sortOptions[0]);
        }
    }


    return(
        <TextField
        id="outlined-select-currency"
        select
        value={sortOrder.label}
        onChange={onSortChange}
        sx={{margin:'4px',width:'10%'}}
    >
        {
            sortOptions.map((option) => (
                <MenuItem key={option.value} value={option.label}>
                    {option.label}
                </MenuItem>
            ))}
    </TextField>
    )
}

export default SortFilter