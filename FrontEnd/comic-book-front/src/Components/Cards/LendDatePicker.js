import { LocalizationProvider } from "@mui/x-date-pickers";
import { AdapterDateFns } from "@mui/x-date-pickers/AdapterDateFns";
import { useState } from "react";
import DatePicker from "react-datepicker"
import 'react-datepicker/dist/react-datepicker.css'
import { getTimePeriods } from "../../services/LendService";
import { useEffect } from "react";
export default function LendDatePicker() {
    const [date, setDate] = useState(new Date())
    const [highlights, setHighlights] = useState([])
    const onChange = (newDate) => {
        setDate(newDate)
    }

    const loadDates = async () => {
        const response = await getTimePeriods(14)
        const dates = []
        const timePeriods = response
        timePeriods.forEach(element => {
            const startDate = new Date(element.startDate)
            const endDate = new Date(element.endDate)
            while (startDate <= endDate) {
                dates.push(new Date(startDate))
                var date = new Date(startDate);
                startDate.setDate(date.getDate() + 1);
            }
        })
        setHighlights(dates)
    }
    useEffect(() => { loadDates() }, []);
    return (
        <DatePicker
            highlightDates={highlights}>

        </DatePicker>
    )
}