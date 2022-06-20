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
import { Controller } from "react-hook-form";
import { useNavigate } from "react-router";

function NewLend(props) {
    const { comicBook } = props
    const [showMessage, setShowMessage] = useState(false)
    const [message, setMessage] = useState('')
    const [status, setStatus] = useState(0)
    const { register, handleSubmit, formState: { errors }, control } = useForm({
        resolver: joiResolver(lendDateSchema),
    });
    const navigate = useNavigate()

    const onBorrowClick = async (data) => {
        const body = {
            startDate: data.startLendDate,
            endDate: data.endLendDate
        }
        const result = await newLend(body, comicBook.id)
        if (result.status === 201) {
            setShowMessage(true)
            setMessage(result.message)
            setStatus(result.status)
        }
        else if (result.status === 401) {
            localStorage.clear()
            navigate('/LogIn')
        }
        else {
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

                <Controller
                    name="startLendDate"
                    defaultValue={new Date()}
                    control={control}
                    render={({ field }) =>
                        <LocalizationProvider dateAdapter={AdapterDateFns}  >
                            <DatePicker
                                label="Start Date"
                                value={field.value}
                                inputFormat="dd/MM/yyyy"
                                onChange={(evt) => {
                                    field.onChange(evt)
                                }}
                                defaultValue={new Date(Date.now())}
                                renderInput={(params) => <TextField
                                    {...params}
                                    helperText={errors ? errors.startLendDate?.message : null}
                                />} />
                        </LocalizationProvider>
                    } />
            </Box>
            <Box sx={{ margin: '1%' }}>
                <Controller
                    name="endLendDate"
                    defaultValue={new Date(Date.now())}
                    control={control}
                    render={({ field }) =>
                        <LocalizationProvider dateAdapter={AdapterDateFns}>
                            <DatePicker
                                label="End Date"
                                inputFormat="dd/MM/yyyy"
                                value={field.value}
                                onChange={(evt) => {
                                    field.onChange(evt)
                                }}
                                renderInput={(params) => <TextField
                                    {...params}
                                    helperText={errors ? errors.endLendDate?.message : null} />}
                            />
                        </LocalizationProvider>}
                >
                </Controller>
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