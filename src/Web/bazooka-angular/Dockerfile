FROM node:latest as build 
WORKDIR /app
COPY . .
RUN npm run build
FROM nginx:latest
COPY --from=build /app/dist/bazooka-angular/browser /usr/share/nginx/html
EXPOSE 80