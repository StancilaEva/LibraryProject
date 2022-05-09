
import { useState } from "react";
import { Button } from "@mui/material";
import { Box } from "@mui/system";
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { DatePicker } from "@mui/x-date-pickers";
import { TextField } from "@mui/material";
import { AdapterDateFns } from '@mui/x-date-pickers/AdapterDateFns';
import Alert from '@mui/material/Alert';
import IconButton from '@mui/material/IconButton';
import Collapse from '@mui/material/Collapse';
import CloseIcon from '@mui/icons-material/Close';
import api from "../../api/posts"
import { AxiosError } from "axios";
import SuccessfulLend from "./Toasts/SuccesfulLend";
import UnsuccessfulLend from "./Toasts/UnsuccessfulLend";
import { newLend } from "../../services/LendService";



function NewLend(props) {
    const { comicBook } = props
    const [startDate, setStartDate] = useState(new Date(Date.now()))
    const [endDate, setEndDate] = useState(new Date(Date.now()))
    const [showMessage, setShowMessage] = useState(false)
    const [message, setMessage] = useState('')
    const [status, setStatus] = useState(0)

    const onBorrowClick = async () => {
        const body = {
            startDate,
            endDate
        }
        const result = await newLend(body, comicBook.id)
        if (result.status === 201) {
            setShowMessage(true)
            setMessage(result.message)
            setStatus(result.status)
        }
        else
            if (result.status === 400) {
                setMessage(result.message)
                setShowMessage(true)
                setStatus(result.status)
            }
    }

    const renderMessage = () => {
        if (status === 201) {
            return (<SuccessfulLend setShowMessage={setShowMessage} message={message} showMessage={showMessage} />)
        }
        else {
            return (<UnsuccessfulLend setShowMessage={setShowMessage} message={message} showMessage={showMessage} />)
        }
    }

    return (
        <>
            <Box sx={{ margin: '1%' }}>
                <LocalizationProvider dateAdapter={AdapterDateFns}  >
                    <DatePicker
                        label="Start Date"
                        value={startDate}
                        onChange={(evt) => {
                            setStartDate(evt);
                        }}
                        renderInput={(params) => <TextField {...params} />}
                    />
                </LocalizationProvider>
            </Box>
            <Box sx={{ margin: '1%' }}>
                <LocalizationProvider dateAdapter={AdapterDateFns}>
                    <DatePicker
                        label="End Date"
                        value={endDate}
                        onChange={(evt) => {
                            setEndDate(evt);
                        }}
                        renderInput={(params) => <TextField {...params} />}
                    />
                </LocalizationProvider>
            </Box>
            <Button
                onClick={() => { onBorrowClick() }}>
                Borrow
            </Button>
            <Box sx={{ width: '30%', position: "absolute", bottom: 0 }} >
                <Collapse in={showMessage}>
                    {renderMessage()}
                </Collapse>
            </Box>
        </>
    )
}

export default NewLend