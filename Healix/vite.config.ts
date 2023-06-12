import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'
import fs from 'fs'
import { VitePWA } from 'vite-plugin-pwa'

// https://vitejs.dev/config/
export default defineConfig({
    plugins: [
        react(),
        // VitePWA({
        //     injectRegister: 'auto',
        //     registerType: 'autoUpdate',
        //     manifest: {
        //         start_url: "/",
        //         name: 'Healix - by Antidote',
        //         short_name: 'Healix',
        //         display: 'standalone',
        //         description: 'Intelligent Telemedicine for the Medical Sector',
        //         theme_color: '#ffffff',
        //         icons: [
        //           {
        //             src: './icons/emblem@512.png',
        //             sizes: '512x512',
        //             type: 'image/png'
        //           },
        //           {
        //             src: './icons/emblem-apple.png',
        //             sizes: '192x192',
        //             type: 'image/png'
        //           }
        //         ]
        //     },
        //     devOptions: {
        //         enabled: false
        //       }
        // })
        // VitePWA ({
        //     scope: '/',
        //     injectRegister: 'auto',
        //     registerType: 'autoUpdate',
        //     strategies: 'generateSW',
        //     manifest: {
        //         start_url: "/",
        //         name: 'Healix - by Antidote',
        //         short_name: 'Healix',
        //         display: 'standalone',
        //         description: 'Intelligent Telemedicine for the Medical Sector',
        //         theme_color: '#ffffff',
        //         icons: [
        //           {
        //             src: './icons/emblem@512.png',
        //             sizes: '512x512',
        //             type: 'image/png'
        //           },
        //           {
        //             src: './icons/emblem-apple.png',
        //             sizes: '192x192',
        //             type: 'image/png'
        //           }
        //         ]
        //     },
        //     workbox: {
        //         clientsClaim: true,
        //         skipWaiting: true
        //       },
        //     devOptions: {
        //         enabled: true
        //       }
        // })
    ],
    css: {
        postcss: {
            plugins : [
                // autoprefixer
                require('autoprefixer')
            ]
        }
    },
    server: {
        https: {
            key: fs.readFileSync('./localhost-key.pem'),
            cert: fs.readFileSync('./localhost.pem'),
        },
        host: '::',
        port: 3000,
        watch: {
            ignored: [
                "**/*.fs"
            ]
        },
        proxy: {
            '/api/negotiate': {
                target: 'http://localhost:7029',
                changeOrigin: true,
                secure: true
            },
            '/api': {
                target: 'http://0.0.0.0:7071',
                changeOrigin: true,
                secure: true
            }
        }
    }
})


// {"start_url":"/","display":"standalone","background_color":"#ffffff","lang":"en","scope":"/"}
