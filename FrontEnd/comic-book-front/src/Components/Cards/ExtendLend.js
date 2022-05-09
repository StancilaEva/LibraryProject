import { useState } from "react";
import { Button} from "@mui/material";
import { Box } from "@mui/system";
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { DatePicker } from "@mui/x-date-pickers";
import { TextField } from "@mui/material";
import { AdapterDateFns } from '@mui/x-date-pickers/AdapterDateFns';
import { extendLend } from "../../services/LendService";
import { Collapse } from "@mui/material";
import SuccessfulLend from "../Cards/Toasts/SuccesfulLend";
import UnsuccessfulLend from "../Cards/Toasts/UnsuccessfulLend";

function ExtendLend(props) {
    const {id,setUpdated} = props
    const [newEndDate, setExtendedDate] = useState(new Date(Date.now()))
    const [showMessage, setShowMessage] = useState(false)
    const [message,setMessage] = useState('')
    const [status,setStatus] = useState(0)

    const onExtendLendClick = async () => {
        const result = await extendLend(id,newEndDate)
        setStatus(result.status)
        setMessage(result.message)
        if(result.status==200){
            setUpdated(true)
        }
        else{
        setShowMessage(true)
        }
    }

    const renderToast =  () =>{
            return (<UnsuccessfulLend setShowMessage={setShowMessage} message={message} showMessage={showMessage} />)
        
    }

    return (
        <Box sx={{ display: "flex", flexDirection: "column", justifyContent: "center", alignItems: "center" }}>
        <LocalizationProvider dateAdapter={AdapterDateFns}  >
            <DatePicker
                label="Extend Date"
                value={newEndDate}
                onChange={(evt) => {
                    setExtendedDate(evt);
                }}
                renderInput={(params) => <TextField {...params} />}
            />
        </LocalizationProvider>
        <Button
            onClick={() => { onExtendLendClick() }}>
            Extend
        </Button>
        <Collapse in={showMessage}>
            {
            renderToast() 
            }
        </Collapse>
    </Box>
    )
}
export default ExtendLend