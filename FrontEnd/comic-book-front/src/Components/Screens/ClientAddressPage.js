import { useParams } from "react-router-dom";
import ApplicationMenuBar from "../Cards/ApplicationMenuBar";
import { useContext, useEffect, useState } from "react";
import TextField from '@mui/material/TextField';
import { Box } from "@mui/system";
import { Button } from "@mui/material";
import { getAddress, modifyAddress } from "../../services/ClientService";
import { UserContext } from "../../Context/userContext";
import Collapse from '@mui/material/Collapse';
import SuccessfulMessage from "../Cards/Toasts/SuccesfulMessage";
import UnsuccessfulMessage from "../Cards/Toasts/UnsuccessfulMessage";
import { useForm } from "react-hook-form";
import { addressSchema } from "../../validators/addressSchema";
import { joiResolver } from '@hookform/resolvers/joi';

function ClientAddress() {
    const [county, setCounty] = useState('')
    const [city, setCity] = useState('')
    const [street, setStreet] = useState('')
    const [number, setNumber] = useState(0)
    const [showMessage, setShowMessage] = useState(false)
    const [message, setMessage] = useState('')
    const [status, setStatus] = useState(0)
    const { register, handleSubmit, formState: { errors },watch } = useForm({
        resolver: joiResolver(addressSchema),
      });
    //pune axios!!!
    const loadAddress = async () => {
        const response = await getAddress()
        setCounty(response.county)
        setCity(response.city)
        setStreet(response.street)
        setNumber(response.number)

    }

    const changeAddress = async (data) => {
        const result = await modifyAddress(county, city, street, number)
        if (result.status === 200) {
            setCity(result.address.city)
            setCounty(result.address.county)
            setStreet(result.address.street)
            setNumber(result.address.number)
            setMessage(result.address.message)
            setShowMessage(true)
            setMessage(result.message)
            setStatus(result.status)
        }
        else {
            setShowMessage(true)
            setMessage(result.message)
            setStatus(result.status)
        }
    }

    console.log(errors)
    useEffect(() => { loadAddress() }, [])

    const renderMessage = () => {
        if (status === 200) {
            return (<SuccessfulMessage setShowMessage={setShowMessage} message={message} showMessage={showMessage} />)
        }
        else {
            return (<UnsuccessfulMessage setShowMessage={setShowMessage} message={message} showMessage={showMessage} />)
        }
    }

    return (
        <div>
            <ApplicationMenuBar></ApplicationMenuBar>
            <Box component="form" sx={{ display: "flex", flexDirection: "column", justifyContent: "center", alignItems: "center", height: '75vh' }} >
                <TextField
                    required
                    value={county}
                    {...register("county")}
                    sx={{ width: 200, marginBottom: 1 }}
                    onChange={evt => setCounty(evt.target.value)}
                    helperText={errors ? errors.county?.message : null}>
                </TextField>
                <TextField
                    required
                    value={city}
                    {...register("city")}
                    sx={{ width: 200, marginBottom: 1 }}
                    onChange={evt => setCity(evt.target.value)}
                    helperText={errors ? errors.city?.message : null}>
                </TextField>
                <TextField
                    required
                    {...register("street")}
                    sx={{ width: 200, marginBottom: 1 }}
                    value={street}
                    onChange={evt => setStreet(evt.target.value)}
                    helperText={errors ? errors.street?.message : null}>
                </TextField>
                <TextField
                    required
                    sx={{ width: 200, marginBottom: 1 }}
                    value={number}
                    type="number"
                    {...register("number")}
                    inputProps={{ min: 0, inputMode: 'numeric', pattern: '[0-9]*' }}
                    onChange={event => setNumber(event.target.value)}
                    helperText={errors ? errors.email?.number : null}>
                </TextField>
                <Button variant="outlined" onClick={handleSubmit(changeAddress)} sx={{ marginBottom: 1 }}>
                    Change Address
                </Button>
                <Box sx={{ width: '30%', position: "absolute", bottom: 0 }} >
                <Collapse in={showMessage}>
                    {renderMessage()}
                </Collapse>
            </Box>
            </Box>
        </div>)
}
export default ClientAddress;