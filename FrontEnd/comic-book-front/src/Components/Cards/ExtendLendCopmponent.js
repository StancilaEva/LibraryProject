import { useContext, useState } from "react";
import { Button } from "@mui/material";
import { Box } from "@mui/system";
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { DatePicker } from "@mui/x-date-pickers";
import { TextField } from "@mui/material";
import { AdapterDateFns } from '@mui/x-date-pickers/AdapterDateFns';
import { extendLend } from "../../services/LendService";
import { Collapse } from "@mui/material";
import UnsuccessfulMessage from "./Toasts/UnsuccessfulMessage";
import { useForm } from 'react-hook-form';
import { joiResolver } from '@hookform/resolvers/joi';
import { extendDateSchema } from "../../validators/extendDateSchema";
import { Controller } from "react-hook-form";


function ExtendLend(props) {
    const { id, setUpdated } = props
    //const [newEndDate, setExtendedDate] = useState(new Date(Date.now()))
    const [showMessage, setShowMessage] = useState(false)
    const [message, setMessage] = useState('')
    const [status, setStatus] = useState(0)
    const { register, handleSubmit, formState: { errors }, control } = useForm({
        resolver: joiResolver(extendDateSchema)
    })

    const onExtendLendClick = async (data) => {
        const result = await extendLend(id, data.endLendDate)
        setStatus(result.status)
        setMessage(result.message)
        if (result.status == 200) {
            setUpdated(true)
        }
        else {
            setShowMessage(true)
        }
    }

    const renderToast = () => {
        return (<UnsuccessfulMessage setShowMessage={setShowMessage} message={message} showMessage={showMessage} />)

    }

    return (
        <Box sx={{ display: "flex", flexDirection: "column", justifyContent: "center", alignItems: "center" }}>
            <Controller
                name="endLendDate"
                defaultValue={new Date(Date.now())}
                control={control}
                render={({ field }) =>
                    <LocalizationProvider dateAdapter={AdapterDateFns}>
                        <DatePicker
                            label="End Date"
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
            <Button
                onClick={handleSubmit(onExtendLendClick)}>
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