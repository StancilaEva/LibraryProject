import { useEffect } from "react"
import { MenuItem } from "@mui/material"
import { TextField } from "@mui/material"
import { useState } from "react"

const TimeFilter = (props) =>{
    const {filterTime,setFilterTime,setPage} = props
    const timePeriods = [
        {
          value: -1,
          label: 'Empty',
        },
        {
          value: 0,
          label: 'Past',
        },
        {
          value: 1,
          label: 'Present',
        },
        {
          value: 2,
          label: 'Future',
        },
      ];


    const onFilterTimeChange = (evt) => {
        const value = evt.target.value;
        setFilterTime(value)
        setPage(1)
    }

    return(
        <TextField 
            select
            label={"Time Period"}
            value={filterTime}
            onChange={onFilterTimeChange}
            sx={{margin:'4px',width:'10%'}}
        >
            {
                timePeriods.map((option) => (
                    <MenuItem key={option.value} value={option.value}>
                        {option.label}
                    </MenuItem>
                ))}
        </TextField>
    )
}

export default TimeFilter