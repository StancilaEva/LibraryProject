import { useEffect } from "react"
import { MenuItem } from "@mui/material"
import { TextField } from "@mui/material"
import { useState } from "react"
import { getPublishers } from "../../../services/ComicBooksService"

const PublisherFilter = (props) =>{
    const {filterPublisher,setFilterPublisher,setPage} = props
    const [publishers, setPublishers] = useState([""])

    const loadFilterPublishers = async () =>{
        const publishersResponse = await getPublishers()
        setPublishers(publishersResponse.publishers)
    }

    const onFilterPublisherChange = (evt) => {
        const value = evt.target.value;
        setFilterPublisher(value)
        setPage(1)
    }

    useEffect(()=>{loadFilterPublishers()},[])

    return(
        <TextField
            select
            label={"Publisher"}
            value={filterPublisher}
            onChange={onFilterPublisherChange}
            sx={{margin:'4px',width:'10%'}}
        >
            {
                publishers.map((option) => (
                    <MenuItem key={option} value={option}>
                        {option===""?"Empty":option}
                    </MenuItem>
                ))}
        </TextField>
    )
}

export default PublisherFilter