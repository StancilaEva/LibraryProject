
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



function NewLend(props) {
    const { comicBook } = props
    const [startDate, setStartDate] = useState(new Date(Date.now()))
    const [endDate, setEndDate] = useState(new Date(Date.now()))
    const [showMessage, setShowMessage] = useState(false)
    const [message, setMessage] = useState('successful')
    const [errorMessage, setErrorMessage] = useState('')

    const onBorrowClick = async () => {
        const body = {
            startDate,
            endDate
        }
        const request = await fetch(`https://localhost:7015/api/Lends/1/comicBook/${comicBook.id}`,
            {
                mode: 'cors',
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(body)
            });
        if (request.status === 201) {
            setShowMessage(true)
            setMessage("successful")
        }
        else
            if (request.status === 400) {
                const response = await request.json()
                setMessage(response.errorMessage)
                setShowMessage(true)
            }
    }

    const renderMessage = () => {
        if (message == 'successful') {
            return (<SuccessfulLend setShowMessage={setShowMessage} showMessage={showMessage} />)
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