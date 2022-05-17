import { useState } from "react";
import { Button } from "@mui/material";
import { Box } from "@mui/system";
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { DatePicker } from "@mui/x-date-pickers";
import { TextField } from "@mui/material";
import { AdapterDateFns } from '@mui/x-date-pickers/AdapterDateFns';
import Collapse from '@mui/material/Collapse';
import SuccessfulMessage from "./Toasts/SuccesfulMessage";
import UnsuccessfulMessage from "./Toasts/UnsuccessfulMessage";
import { newLend } from "../../services/LendService";
import { useForm } from 'react-hook-form';
import { joiResolver } from '@hookform/resolvers/joi';
import { lendDateSchema } from "../../validators/lendDateSchema";


function NewLend(props) {
    const { comicBook } = props
    const [startDate, setStartDate] = useState(new Date(Date.now()))
    const [endDate, setEndDate] = useState(new Date(Date.now()))
    const [showMessage, setShowMessage] = useState(false)
    const [message, setMessage] = useState('')
    const [status, setStatus] = useState(0)
    const { register, handleSubmit, formState: { errors },watch } = useForm({
        resolver: joiResolver(lendDateSchema),
      });
    const startLendDate = register("startLendDate")
    const endLendDate = register("endLendDate")

    const onBorrowClick = async (data) => {
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
            return (<SuccessfulMessage setShowMessage={setShowMessage} message={message} showMessage={showMessage} />)
        }
        else {
            return (<UnsuccessfulMessage setShowMessage={setShowMessage} message={message} showMessage={showMessage} />)
        }
    }

    return (
        <>
            <Box sx={{ margin: '1%' }}>
                <LocalizationProvider dateAdapter={AdapterDateFns}  >
                    <DatePicker
                        {...startLendDate}
                        label="Start Date"
                        value={startDate}
                        onChange={(evt) => {
                            setStartDate(evt);
                        }}
                        renderInput={(params) => <TextField 
                         {...params}
                         helperText={errors ? errors.startLendDate?.message : null} 
                         />}
                        
                    />
                </LocalizationProvider>
            </Box>
            <Box sx={{ margin: '1%' }}>
                <LocalizationProvider dateAdapter={AdapterDateFns}>
                    <DatePicker
                        label="End Date"
                        {...endLendDate}
                        value={endDate}
                        onChange={(evt) => {
                            setEndDate(evt);
                        }}
                        renderInput={(params) => <TextField 
                        {...params}
                        helperText={errors ? errors.endLendDate?.message : null}/>}
                        
                    />
                </LocalizationProvider>
            </Box>
            <Button
                onClick={handleSubmit(onBorrowClick)}>
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