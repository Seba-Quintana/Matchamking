import React from 'react'
import styled from 'styled-components'

const MiddleButtonStyle = styled.div`
    background-color: #f55252;
    width: 90%;
    max-width: 500px;
    height: 50px;
    display: flex;
    align-items: center;
    justify-content: center;
    border-radius: 5px;
    @media (max-width: 800px){
    align-self: center;
}
`

export default MiddleButtonStyle